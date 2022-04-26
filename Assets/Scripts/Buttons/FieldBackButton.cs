using UnityEngine;

public class FieldBackButton : MonoBehaviour
{
    [SerializeField]
    private UIPage _level;
    [SerializeField]
    private UIPage _infinityLevel;
    [SerializeField]
    private UIGroupSelector _groupSelector;
    [SerializeField]
    private CurrentLevel _currentLevel;

    public void Back()
    {
        if(_currentLevel.Level.CompletionCondition is FullCellCompletionCondition)
        {
            _groupSelector.SetActivePage(_level);
        }
        else if(_currentLevel.Level.CompletionCondition is ScoreCompletionCondition)
        {
            _groupSelector.SetActivePage(_infinityLevel);
        }
    }
}
