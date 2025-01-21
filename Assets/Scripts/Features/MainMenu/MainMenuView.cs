using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _greeting;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private Button _counterButton;
    [SerializeField] private Button _updateContentButton;
    private LocalServer _localServer;
    private AppData _appData;
    private int _currentCounter;

    private void Awake()
    {
        _counterButton.onClick.AddListener(UpdateCounter);
        _updateContentButton.onClick.AddListener(()=>UpdateContent());
    }

    public void UpdateData(AppData appData, LocalServer localServer, int counter)
    {
        _greeting.text = appData.Message;
        _buttonImage.sprite = appData.ButtonSprite;
        _counter.text = counter.ToString();
        _currentCounter = counter;
        _localServer = localServer;
        _appData = appData;
    }

    private void UpdateCounter()
    {
        _currentCounter += 1;
        _counter.text = _currentCounter.ToString();
        SaveSystem.SaveCounter(_currentCounter);
    }

    private async UniTask UpdateContent()
    {
        await UpdateDataService.UpdateData(_localServer,_appData);
        _greeting.text = _appData.Message;
        _counter.text = _appData.StartingNumber.ToString();
        _currentCounter = _appData.StartingNumber;
        _buttonImage.sprite = _appData.ButtonSprite;
        SaveSystem.SaveCounter(_currentCounter);
    }
}
