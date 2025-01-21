using Cysharp.Threading.Tasks;
using UnityEngine;

public class MainMenuState : IState
{
    private AppManager _appManager;
    private UIService _uiService;
    private AppData _appData;

    public MainMenuState(AppManager appManager, UIService uiService, AppData appData)
    {
        _appManager = appManager;
        _uiService = uiService;
        _appData = appData;
    }

    public async void Enter()
    {
        var mainMenuView = await _uiService.ShowMainScreen();
        mainMenuView.UpdateData(_appData.Message, _appData.ButtonSprite, _appData.StartingNumber);
    }

    public void Exit()
    {
      
    }
}