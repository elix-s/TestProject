using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private RectTransform _progressLineTransform;
    private bool _loaded = false;

    private async void Start()
    {
        _progressLineTransform.DOScaleX(1.0f, 3.0f);
        await UniTask.Delay(3000);
        _loaded = true;
    }

    public bool GetStatus()
    {
        return _loaded;
    }
}
