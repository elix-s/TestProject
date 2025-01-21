using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class LocalServer : MonoBehaviour
{
    public const string JsonName_Settings = "Settings.json";
    public const string JsonName_Greeting = "Greeting.json";
    private string _assetBundlesPath;
    
    private string streamingAssetsPath;

    public void Init()
    {
        streamingAssetsPath = Application.streamingAssetsPath;
        _assetBundlesPath = Path.Combine(Application.dataPath, "AssetBundles");
        
        if (!Directory.Exists(streamingAssetsPath))
        {
            Directory.CreateDirectory(streamingAssetsPath);
        }
        
        CreateFile(JsonName_Settings, "{ \"startingNumber\": 5 }");
        CreateFile(JsonName_Greeting, "{ \"message\": \"Добро пожаловать в игру\" }");
    }

    private void CreateFile(string fileName, string content)
    {
        string filePath = Path.Combine(streamingAssetsPath, fileName);
        
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, content);
        }
    }

    public async UniTask<string> LoadJson(string fileName)
    {
        string filePath = Path.Combine(streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
            return await File.ReadAllTextAsync(filePath);
        }

        Debug.LogError($"File not found: {filePath}");
        return null;
    }
    
    public Sprite LoadSpriteFromBundle(string bundleName, string spriteName)
    {
        string bundlePath = Path.Combine(_assetBundlesPath, bundleName);

        if (!File.Exists(bundlePath))
        {
            Debug.LogError($"Asset Bundle not found at path: {bundlePath}");
            return null;
        }
        
        AssetBundle bundle = AssetBundle.LoadFromFile(bundlePath);
        
        if (bundle == null)
        {
            Debug.LogError($"Failed to load Asset Bundle: {bundleName}");
            return null;
        }
        
        Sprite sprite = bundle.LoadAsset<Sprite>(spriteName);
        
        if (sprite == null)
        {
            Debug.LogError($"Sprite '{spriteName}' not found in Asset Bundle '{bundleName}'");
        }
        
        bundle.Unload(false);

        return sprite;
    }
}