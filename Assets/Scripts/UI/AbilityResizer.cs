using UnityEngine;

public class AbilityResizer : GridResizer
{
    protected override void ChangeCellSize()
    {
        GridGroup.cellSize = new Vector2(Panel.rect.height, Panel.rect.height);
    }
}
