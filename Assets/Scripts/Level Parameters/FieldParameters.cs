using UnityEngine;

[System.Serializable]
public class FieldParameters
{
    [SerializeField] [Range(2, 10)]
    private int _height = 2;
    [SerializeField] [Range(2, 10)]
    private int _width = 2;
    [SerializeField]
    private int _fullInRow;
    [SerializeField]
    private int _fullInColumn;
    [SerializeField] [HideInInspector]
    private BoolMap[] _map;

    public int Height => _height;
    public int Width => _width;
    public int FullInRow => _fullInRow;
    public int FullInColumn => _fullInColumn;
    public BoolMap[] Map => _map;

    public void OnValidate()
    {
        if(_map?.Length != Width || _map[0].Length != Height)
        {
            BoolMap[] temp = new BoolMap[Width];
            for(int i = 0; i < temp.Length; i++)
            {
                temp[i] = new BoolMap(Height);
                for(int j = 0; j < temp[i].Length; j++)
                {
                    if(i < _map?.Length && j < _map[i]?.Length)
                    {
                        temp[i][j] = _map[i][j];
                    }
                    else
                    {
                        temp[i][j] = true;
                    }
                }
            }
            _map = temp;
        }
    }
}
