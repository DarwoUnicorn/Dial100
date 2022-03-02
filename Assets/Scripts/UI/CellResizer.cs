using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellResizer : MonoBehaviour
{
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup;
    [SerializeField]
    private RectTransform _field;
    [SerializeField]
    private GameParameters _gameParameters;

    private Vector2 _previousSize;
    private int _space = 25;

    private void Start()
    {
        _previousSize = new Vector2(_field.rect.width, _field.rect.height);
    }

    private void Update()
    {
        if(_previousSize.x != _field.rect.width || _previousSize.y != _field.rect.height)
        {
            ChangeCellSize();
        }
    }

    public void ChangeCellSize()
    {
        float cellSize = (Mathf.Min(_field.rect.width, _field.rect.height) - 
                         _space * Mathf.Min(_gameParameters.Height, _gameParameters.Width) + 1) / 
                         Mathf.Min(_gameParameters.Height, _gameParameters.Width);
        _gridLayoutGroup.cellSize.Set(cellSize, cellSize);
    }
}
