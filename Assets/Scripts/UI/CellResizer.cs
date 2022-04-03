using UnityEngine;

public class CellResizer : GridResizer
{
    private GameParameters _parameters;
    private int _space = 25;

    public void SetParameters(GameParameters parameters)
    {
        _parameters = parameters;
        ChangeCellSize();
    }

    protected override void ChangeCellSize()
    {
        if(_parameters == null)
        {
            throw new System.ArgumentNullException(_parameters.ToString());
        }
        float verticalSize = (Panel.rect.height - _space * (_parameters.Height + 1)) / _parameters.Height;
        float horizontalSize = (Panel.rect.width - _space * (_parameters.Width + 1)) / _parameters.Width;
        float cellSize = Mathf.Min(horizontalSize, verticalSize);
        GridGroup.constraintCount = _parameters.Width;
        GridGroup.cellSize = new Vector2(cellSize, cellSize);
    }

    protected override void Update()
    {
        if(_parameters == null)
        {
            return;
        }
        base.Update();
    }
}
