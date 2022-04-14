using UnityEngine;

[System.Serializable]
public class FullCellCompletionCondition : LevelCompletionCondition
{
    [SerializeField]
    private int _requiredFullCells;

    public int RequiredFullCells => _requiredFullCells;

    public override void CheckCondition(int value)
    {
        if(_requiredFullCells <= value)
        {
            Complete();
        }
    }
}
