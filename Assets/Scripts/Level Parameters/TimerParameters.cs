using UnityEngine;

[System.Serializable]
public class TimerParameters
{
    [SerializeField] [Range(1, 100)]
    private float _maxTime = 1;
    [SerializeField] [Range(1, 100)]
    private float _minTime = 1;

    public float MaxTime => _maxTime;
    public float MinTime => _minTime;

    private float _previousMaxTime;
    private float _previousMinTime;

    public void OnValidate()
    {
        if(_maxTime < _minTime)
        {
            if(_previousMaxTime != _maxTime)
            {
                _minTime = _maxTime;
            }
            else
            {
                _maxTime = _minTime;
            }
        }
        if(_previousMaxTime != _maxTime)
        {
            _previousMaxTime = _maxTime;
        }
        if(_previousMinTime != _minTime)
        {
            _previousMinTime = _minTime;
        }
    }
}
