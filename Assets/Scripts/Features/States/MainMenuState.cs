public class MainMenuState : IState
{
    private UIService _uiService;
    private AppData _appData;
    private LocalServer _localServer;

    public MainMenuState(UIService uiService, AppData appData, LocalServer localServer)
    {
        _uiService = uiService;
        _appData = appData;
        _localServer = localServer;
    }

    public async void Enter()
    {
        var mainMenuView = await _uiService.ShowMainScreen();
        var counter = SaveSystem.LoadCounter(0);

        if (counter == 0) counter = _appData.StartingNumber;
            
        mainMenuView.UpdateData(_appData, _localServer, counter);
    }

    public void Exit()
    {
      _uiService.HideMainScreen();
    }
}