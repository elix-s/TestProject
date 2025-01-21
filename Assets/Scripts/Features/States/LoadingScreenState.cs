using Cysharp.Threading.Tasks;
using UnityEngine;

public class LoadingScreenState : IState
{
    private UIService _uiService;
    private LocalServer _localServer;
    private StateMachine _stateMachine;
    private AppData _appData;

    public LoadingScreenState(UIService uiService, LocalServer localServer, 
        StateMachine stateMachine, AppData appData)
    {
       _uiService = uiService;
       _localServer = localServer;
       _stateMachine = stateMachine;
       _appData = appData;
    }

    public async void Enter()
    {
        var loadingView = await _uiService.ShowLoadingScreen();
        
        await UpdateDataService.UpdateData(_localServer,_appData);
        
        await UniTask.WaitUntil(() => loadingView.GetProgressBarStatus());
        
        if (_appData.StartingNumber != 0 && !string.IsNullOrEmpty(_appData.Message) && _appData.ButtonSprite != null)
        {
            _stateMachine.ChangeState(new MainMenuState(_uiService, _appData, _localServer));
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