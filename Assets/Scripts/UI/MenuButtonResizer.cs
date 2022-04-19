using UnityEngine;

public class MenuButtonResizer : GridResizer
{

    private float _space = 50;

    protected override void ChangeCellSize()
    {
        float verticalSize = (Panel.rect.height - _space) / 2;
        float horizontalSize = (Panel.rect.width - _space) / 2;
        float cellSize = Mathf.Min(horizontalSize, verticalSize);
        GridGroup.cellSize = new Vector2(cellSize, cellSize);
    }
}
