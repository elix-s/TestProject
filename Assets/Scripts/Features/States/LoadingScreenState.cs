using Cysharp.Threading.Tasks;

public class LoadingScreenState : IState
{
    private AppManager appManager;
    private UIService _uiService;

    public LoadingScreenState(AppManager appManager, UIService uiService)
    {
        this.appManager = appManager;
       _uiService = uiService;
    }

    public async void Enter()
    {
        _uiService.ShowLoadingScreen().Forget();
    }

    public void Exit()
    {
        
    }
}