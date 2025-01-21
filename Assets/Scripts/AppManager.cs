using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    [SerializeField] private UIService _uiService;
    private StateMachine _stateMachine;
    
    private void Awake()
    {
        _stateMachine = new StateMachine();
        _uiService.Init();
        _stateMachine.ChangeState(new LoadingScreenState(this, _uiService));
    }
}

