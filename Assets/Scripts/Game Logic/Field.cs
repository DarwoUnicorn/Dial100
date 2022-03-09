using System.Collections.Generic;
using UnityEngine;

public class Field
{
    private List<FieldColumn> _gameField = new List<FieldColumn>();

    public Field(GameParameters gameParameters)
    {
        for(int i = 0; i < gameParameters.Width; i++)
        {
            _gameField.Add(new FieldColumn(gameParameters.Height));
        }
    }

    public IEnumerable<FieldColumn> GameField => _gameField;

    public FieldColumn this[int index]
    {
        get
        {
            return _gameField[index];
        }
    }

    public Cell this[Vector2Int index]
    {
        get
        {
            return _gameField[index.x][index.y];
        }
    }

    public void DeleteCell(Vector2Int index)
    {
        _gameField[index.x].DeleteCell(index.y);
    }

    public void DeleteColumn(int index)
    {
        int size = _gameField[index].Size;
        _gameField.RemoveAt(index);
        _gameField.Insert(index, new FieldColumn(size));
    }
}
