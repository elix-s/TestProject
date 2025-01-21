using DG.Tweening;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private RectTransform _progressLineTransform;

    private void Start()
    {
        _progressLineTransform.DOScaleX(1.0f, 2.0f);
    }
}
