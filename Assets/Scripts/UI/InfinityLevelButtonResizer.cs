using UnityEngine;

public class InfinityLevelButtonResizer : GridResizer
{
    [SerializeField]
    private Levels _levels;

    private float _space = 25;

    protected override void ChangeCellSize()
    {
        float cellSize = (Panel.rect.width - 2 * _space) / GridGroup.constraintCount;
        GridGroup.cellSize = new Vector2(cellSize, cellSize / 3);
        Panel.offsetMin = new Vector2(Panel.offsetMin.x, -(_levels.List.Count / GridGroup.constraintCount + 1) * (cellSize / 3 + _space));
    }
}
