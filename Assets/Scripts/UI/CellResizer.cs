using UnityEngine;

public class CellResizer : GridResizer
{
    [SerializeField]
    private RectTransform _tempCell;

    private FieldParameters _parameters;
    private int _space = 25;

    public void SetParameters(LevelParameters parameters)
    {
        _parameters = parameters.Field;
        ChangeCellSize();
    }

    protected override void ChangeCellSize()
    {
        if(_parameters == null)
        {
            throw new System.NullReferenceException("Parameters can't be null");
        }
        float verticalSize = (Panel.rect.height - _space * (_parameters.Height + 1)) / _parameters.Height;
        float horizontalSize = (Panel.rect.width - _space * (_parameters.Width + 1)) / _parameters.Width;
        float cellSize = Mathf.Min(horizontalSize, verticalSize);
        GridGroup.constraintCount = _parameters.Width;
        GridGroup.cellSize = new Vector2(cellSize, cellSize);
        _tempCell.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, cellSize);
        _tempCell.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, cellSize);
    }

    #region "MonoBehaviour"

    protected override void Update()
    {
        if(_parameters == null)
        {
            return;
        }
        base.Update();
    }

    #endregion
}
