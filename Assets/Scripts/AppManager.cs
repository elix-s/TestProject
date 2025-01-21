using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    [SerializeField] private UIService _uiService;
    [SerializeField] private LocalServer _localServer;
    private StateMachine _stateMachine;
    private AppData _appData;
    
    private void Awake()
    {
        _stateMachine = new StateMachine();
        _appData = new AppData();
        _uiService.Init();
        _localServer.Init();
        _stateMachine.ChangeState(new LoadingScreenState(this, _uiService, _localServer, _stateMachine, _appData));
    }
}

