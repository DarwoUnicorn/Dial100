using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerLevel
{
    [SerializeField]
    private UnityEvent<int> LevelUp = new UnityEvent<int>();
    [SerializeReference]
    private UnityEvent ExperienceChanged = new UnityEvent();

    [SerializeField]
    private int _value;
    [SerializeField]
    private int _experience;

    public int Value => _value;
    public int Experience => _experience;
    public int ExperienceToNextLevel
    {
        get
        {
            return 10 + 5 * _value;
        }
    }

    public void AddExperience(int experience)
    {
        _experience += experience;
        if(_experience >= ExperienceToNextLevel)
        {
            _experience -= ExperienceToNextLevel;
            _value++;
            LevelUp?.Invoke(_value);
        }
        ExperienceChanged?.Invoke();
    }
}
