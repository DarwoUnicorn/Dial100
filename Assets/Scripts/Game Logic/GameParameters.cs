using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameters : MonoBehaviour
{
    private float _previousMaxTime;
    private float _previousMinTime;

    [SerializeField]
    private GameMode _mode;
    [SerializeField] [Range(2, 10)]
    private int _height = 2;
    [SerializeField] [Range(2, 10)]
    private int _width = 2;
    [SerializeField] [Range(0, 100)]
    private float _maxTime;
    [SerializeField] [Range(0, 100)]
    private float _minTime;
    [SerializeField]
    private bool _allowBonuses;

    public GameMode Mode => _mode;
    public int Height => _height;
    public int Width => _width;
    public float MaxTime => _maxTime;
    public float MinTime => _minTime;
    public bool AllowBonuses => _allowBonuses;

    private void Start()
    {
        _previousMaxTime = _maxTime;
        _previousMinTime = _minTime;
    }

    private void OnValidate()
    {
        if(_maxTime < _minTime)
        {
            if(_previousMaxTime != MaxTime)
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

    public void SetGameParameters(GameParameters gameParameters)
    {
        _mode = gameParameters.Mode;
        _height = gameParameters.Height;
        _width = gameParameters.Width;
        _maxTime = gameParameters.MaxTime;
        _minTime = gameParameters.MinTime;
        _allowBonuses = gameParameters.AllowBonuses;
    }
}
