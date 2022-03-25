using UnityEngine;

public class TimerViewer : MonoBehaviour
{
    [SerializeField]
    private Transform _filler;
    [SerializeField]
    private Timer _timer;

    private void Update()
    {
        if(_timer.IsPaused == true)
        {
            return;
        }
        ChangeTimeView(_timer.RemainingTime / _timer.MaxTime);
    }

    private void ChangeTimeView(float fill)
    {
        _filler.localScale = new Vector3(fill, 1, 1);
    }
}
