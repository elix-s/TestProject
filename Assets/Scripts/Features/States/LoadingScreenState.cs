using System.IO;
using Common.AssetsSystem;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadingScreenState : IState
{
    private AppManager appManager;
    private UIService _uiService;
    private LocalServer _localServer;
    private IAssetProvider _assetProvider;

    public LoadingScreenState(AppManager appManager, UIService uiService, LocalServer localServer)
    {
        this.appManager = appManager;
       _uiService = uiService;
       _localServer = localServer;
       _assetProvider = new AssetProvider();
    }

    public async void Enter()
    {
        _uiService.ShowLoadingScreen().Forget();
        
        var settings = await _localServer.LoadJson(LocalServer.JsonName_Settings);
        var greeting = await _localServer.LoadJson(LocalServer.JsonName_Greeting);
        var sprite = _localServer.LoadSpriteFromBundle("ui_elements", "button");
        
        if (!string.IsNullOrEmpty(settings) && !string.IsNullOrEmpty(greeting) && sprite != null)
        {
            Debug.Log($"JSON Content: {settings}");
        }
        else
        {
            Debug.LogWarning("Data not loading");
        }
    }

    public void Exit()
    {
        
    }
}