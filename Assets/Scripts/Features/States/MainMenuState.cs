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
        var counter = SaveSystem.LoadCounter(0);

        if (counter == 0) counter = _appData.StartingNumber;
            
        mainMenuView.UpdateData(_appData.Message, _appData.ButtonSprite, counter);
    }

    public void Exit()
    {
      
    }
}