using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class LocalServer : MonoBehaviour
{
    private const string JsonName_Settings = "Settings.json";
    private const string JsonName_Greeting = "Greeting.json";
    
    private string streamingAssetsPath;

    private void Awake()
    {
        streamingAssetsPath = Application.streamingAssetsPath;
        
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
}