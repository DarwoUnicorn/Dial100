using UnityEngine;

public class LevelCompletionChecker : MonoBehaviour
{
    private LevelParameters _level;
    
    [SerializeField]
    private Score _score;
    [SerializeField]
    private Field _field;

    public void SetLevel(LevelParameters level)
    {
        _level = level;
    }

    public void CheckCondition()
    {
        if(_level is FinalModeLevelParameters)
        {
            _level.CheckCondition(_field.CountOfFullCell());
        }
        else if(_level is InfinityModeLevelParameters)
        {
            _level.CheckCondition(_score.Points);
        }
        else if(_level is ClearModeLevelParameters)
        {
            return;
        }
    }
}
