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
        float maxVerticalSize = (_field.rect.height - _space * (_gameParameters.Height + 1)) / _gameParameters.Height;
        float maxHorizontalSize = (_field.rect.width - _space * (_gameParameters.Width + 1)) / _gameParameters.Width;
        float cellSize = Mathf.Min(maxHorizontalSize, maxVerticalSize);
        _gridLayoutGroup.constraintCount = _gameParameters.Width;
        _gridLayoutGroup.cellSize = new Vector2(cellSize, cellSize);
    }
}
