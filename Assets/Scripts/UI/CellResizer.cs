using UnityEngine;
using UnityEngine.UI;

public class CellResizer : MonoBehaviour
{
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup;
    [SerializeField]
    private RectTransform _field;

    private GameParameters _gameParameters;
    private Vector2 _previousSize;
    private int _space = 25;

    public void ChangeCellSize(GameParameters gameParameters)
    {
        if(gameParameters == null)
        {
            throw new System.ArgumentNullException(gameParameters.ToString());
        }
        _gameParameters = gameParameters;
        float verticalSize = (_field.rect.height - _space * (_gameParameters.Height + 1)) / _gameParameters.Height;
        float horizontalSize = (_field.rect.width - _space * (_gameParameters.Width + 1)) / _gameParameters.Width;
        float cellSize = Mathf.Min(horizontalSize, verticalSize);
        _gridLayoutGroup.constraintCount = _gameParameters.Width;
        _gridLayoutGroup.cellSize = new Vector2(cellSize, cellSize);
    }

    private void Start()
    {
        _previousSize = new Vector2(_field.rect.width, _field.rect.height);
    }

    private void Update()
    {
        if(_gameParameters == null)
        {
            return;
        }
        if(_previousSize.x != _field.rect.width || _previousSize.y != _field.rect.height)
        {
            ChangeCellSize(_gameParameters);
            _previousSize.x = _field.rect.width;
            _previousSize.y = _field.rect.height;
        }
    }
}
