using UnityEngine;

public class LoadingScreenView : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;

    public bool GetProgressBarStatus()
    {
        return _progressBar.GetStatus();
    }
}
