using System.IO;
using Common.AssetsSystem;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadingScreenState : IState
{
    private AppManager _appManager;
    private UIService _uiService;
    private LocalServer _localServer;
    private IAssetProvider _assetProvider;
    private StateMachine _stateMachine;
    private AppData _appData;

    public LoadingScreenState(AppManager appManager, UIService uiService, LocalServer localServer, 
        StateMachine stateMachine, AppData appData)
    {
        _appManager = appManager;
       _uiService = uiService;
       _localServer = localServer;
       _assetProvider = new AssetProvider();
       _stateMachine = stateMachine;
       _appData = appData;
    }

    public async void Enter()
    {
        var loadingView = await _uiService.ShowLoadingScreen();
        
        var settings = await _localServer.LoadJson(LocalServer.JsonName_Settings);
        var greeting = await _localServer.LoadJson(LocalServer.JsonName_Greeting);
        var sprite = _localServer.LoadSpriteFromBundle("ui_elements", "button");
        _appData.ButtonSprite = sprite;
        
        if (!string.IsNullOrEmpty(settings))
        {
            _appData.StartingNumber = JsonUtility.FromJson<AppData.Settings>(settings).startingNumber;
            Debug.Log(_appData.StartingNumber);
        }
        
        if (!string.IsNullOrEmpty(greeting))
        {
            _appData.Message = JsonUtility.FromJson<AppData.Greeting>(greeting).message;
            Debug.Log(_appData.Message);
        }
        
        await UniTask.WaitUntil(() => loadingView.GetProgressBarStatus());
        
        if (_appData.StartingNumber != 0 && !string.IsNullOrEmpty(_appData.Message) && _appData.ButtonSprite != null)
        {
            _stateMachine.ChangeState(new MainMenuState(_appManager, _uiService, _appData));
        }
        else
        {
            Debug.LogWarning("Data not loading");
        }
    }

    public void Exit()
    {
        _uiService.HideLoadingScreen();
    }
}