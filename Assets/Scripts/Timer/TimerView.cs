using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField]
    private Transform _filler;
    [SerializeField]
    private Timer _timer;

    private void ChangeTimeView(float fill)
    {
        _filler.localScale = new Vector3(fill, 1, 1);
    }

    #region "MonoBehaviour"

    private void Update()
    {
        if(_timer.RemainingTime / _timer.MaxTime == _filler.localScale.x)
        {
            return;
        }
        ChangeTimeView(_timer.RemainingTime / _timer.MaxTime);
    }

    #endregion
}
