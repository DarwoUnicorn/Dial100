public class ClearCompletionCondition : LevelCompletionCondition
{
    public override void CheckCondition(int value)
    {
        if(value > 0)
        {
            Complete();
        }
    }
}
