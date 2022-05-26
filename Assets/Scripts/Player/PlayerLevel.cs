using UnityEngine;
using UnityEngine.Events;

public class PlayerLevel : MonoBehaviour, IPersistent
{
    [SerializeField]
    private UnityEvent<int> LevelUp = new UnityEvent<int>();
    [SerializeField]
    private UnityEvent<int> LevelChanged = new UnityEvent<int>();
    [SerializeField]
    private UnityEvent ExperienceChanged = new UnityEvent();

    [SerializeField]
    private string _id;
    [SerializeField]
    private int _level;
    [SerializeField]
    private int _experience;

    public string Id => _id;
    public int Level => _level;
    public int Experience => _experience;
    public int ExperienceToNextLevel
    {
        get
        {
            if(5 + 3 * _level < 75)
            {
                return 5 + 5 * _level;
            }
            return 75;
        }
    }

    public void AddExperience(int experience)
    {
        _experience += experience;
        if(_experience >= ExperienceToNextLevel)
        {
            _experience -= ExperienceToNextLevel;
            _level++;
            LevelUp?.Invoke(_level);
            LevelChanged?.Invoke(_level);
        }
        ExperienceChanged?.Invoke();
        Save();
    }

    public void Load()
    {
        PlayerLevel temp = gameObject.AddComponent<PlayerLevel>();
        if(Saver.Load(temp, _id))
        {
            _level = temp.Level;
            _experience = temp.Experience;
        }
        Destroy(temp);
        LevelChanged?.Invoke(_level);
        ExperienceChanged?.Invoke();
    }

    public void Save()
    {
        Saver.Save(this);
    }

    #region  "MonoBehaviour"

    private void Start()
    {
        Load();
    }

    #endregion
}
