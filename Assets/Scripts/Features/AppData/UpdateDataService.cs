using Cysharp.Threading.Tasks;
using UnityEngine;

public static class UpdateDataService
{
    public static async UniTask UpdateData(LocalServer localServer, AppData appData)
    {
        var settings = await localServer.LoadJson(LocalServer.JsonName_Settings);
        var greeting = await localServer.LoadJson(LocalServer.JsonName_Greeting);
        var sprite = localServer.LoadSpriteFromBundle("ui_elements", "button");

        if (sprite != null)
        {
            appData.ButtonSprite = sprite;
        }
        
        if (!string.IsNullOrEmpty(settings))
        {
            appData.StartingNumber = JsonUtility.FromJson<AppData.Settings>(settings).startingNumber;
        }
        
        if (!string.IsNullOrEmpty(greeting))
        { 
            appData.Message = JsonUtility.FromJson<AppData.Greeting>(greeting).message;
        }
    }
}
