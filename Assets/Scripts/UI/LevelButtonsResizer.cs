using UnityEngine;

public class LevelButtonsResizer : GridResizer
{
    [SerializeField]
    private Levels _levels;

    private float _space = 25;

    protected override void ChangeCellSize()
    {
        float cellSize = (Panel.rect.width - 2 * _space) / 3;
        GridGroup.cellSize = new Vector2(cellSize, cellSize);
        Panel.offsetMin = new Vector2(Panel.offsetMin.x, -(_levels.List.Count / 3 + 1) * (cellSize + _space));
    }
}
