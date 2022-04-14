using UnityEngine;

[System.Serializable]
public class BoolMap
{
    [SerializeField]
    private bool[] _row;

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