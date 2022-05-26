using UnityEngine;

public class AbilityResizer : GridResizer
{
    protected override void ChangeCellSize()
    {
        float cellSize = Panel.rect.width / 3 - 25 / 2;
        cellSize = cellSize > Panel.rect.height ? Panel.rect.height : cellSize;
        GridGroup.cellSize = new Vector2(cellSize, cellSize);
    }
}
