using UnityEngine;

public class GameParameters : MonoBehaviour
{
    [SerializeField]
    private GameMode _mode;
    [SerializeField] [Range(2, 10)]
    private int _height = 2;
    [SerializeField] [Range(2, 10)]
    private int _width = 2;
    [SerializeField]
    private int _fullInRow;
    [SerializeField]
    private int _fullInColumn;
    [SerializeField] [Range(1, 100)]
    private float _maxTime = 1;
    [SerializeField] [Range(1, 100)]
    private float _minTime = 1;
    [SerializeField] [Range(1, 100)]
    private int _maxStartCellValue = 1;
    [SerializeField] [Range(1, 100)]
    private int _minStartCellValue = 1;
    [SerializeField]
    private bool _allowBonuses;
    [SerializeField]
    private bool[,] _fieldMap;

    private float _previousMaxTime;
    private float _previousMinTime;

    public GameMode Mode => _mode;
    public int Height => _height;
    public int Width => _width;
    public int FullInRow => _fullInRow;
    public int FullInColumn => _fullInColumn;
    public float MaxTime => _maxTime;
    public float MinTime => _minTime;
    public int MaxStartCellValue => _maxStartCellValue;
    public int MinStartCellValue => _minStartCellValue;
    public bool AllowBonuses => _allowBonuses;
    public bool[,] FieldMap => _fieldMap;

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
        if(_fieldMap?.GetLength(0) != Width || _fieldMap?.GetLength(1) != Height)
        {
            bool[,] temp = new bool[Width, Height];
            for(int i = 0; i < temp.GetLength(0); i++)
            {
                for(int j = 0; j < temp.GetLength(1); j++)
                {
                    if(i < _fieldMap?.GetLength(0) && j < _fieldMap?.GetLength(1))
                    {
                        temp[i, j] = _fieldMap[i, j];
                    }
                    else
                    {
                        temp[i, j] = true;
                    }
                }
            }
            _fieldMap = temp;
        }
    }
}
