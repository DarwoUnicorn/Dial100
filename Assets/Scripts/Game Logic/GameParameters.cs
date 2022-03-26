using UnityEngine;

public class GameParameters : MonoBehaviour
{
    [System.Serializable]
    public class BoolMap
    {
        public bool[] _row;

        public BoolMap(int size)
        {
            _row = new bool[size];
        }

        public int Length => _row.Length;

        public bool this[int i]
        {
            get
            {
                return _row[i];
            }
            set
            {
                _row[i] = value;
            }
        }
    }

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
    [SerializeField] [HideInInspector]
    private BoolMap[] _fieldMap;

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
    public BoolMap[] FieldMap => _fieldMap;

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
        if(FieldMap?.Length != Width || FieldMap[0].Length != Height)
        {
            BoolMap[] temp = new BoolMap[Width];
            for(int i = 0; i < Width; i++)
            {
                temp[i] = new BoolMap(Height);
            }
            for(int i = 0; i < temp.Length; i++)
            {
                for(int j = 0; j < temp[i].Length; j++)
                {
                    if(i < FieldMap?.Length && j < FieldMap[i]?.Length)
                    {
                        temp[i][j] = FieldMap[i][j];
                    }
                    else
                    {
                        temp[i][j] = true;
                    }
                }
            }
            _fieldMap = temp;
        }
    }
}
