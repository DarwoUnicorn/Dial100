using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AbilityCount : IPersistent
{
    [SerializeField]
    protected UnityEvent<int> AbilityCountChanged = new UnityEvent<int>();

    [SerializeField] [Min(0)]
    private int _value;
    [SerializeField]
    private string _id;

    public int Value => _value;
    public string Id => _id;

    public void IncreaseAbilityCount(int value)
    {
        if(value < 1)
        {
            throw new System.ArgumentException("Count must be greater than 0");
        }
        _value += value;
        AbilityCountChanged?.Invoke(_value);
        Save();
    }

    public void OnAbilityUsed()
    {
        if(_value < 1)
        {
            throw new System.RankException("Ability count can't be less then 0");
        }
        AbilityCountChanged?.Invoke(--_value);
        Save();
    }

    public void Save()
    {
        Saver.Save(this);
    }

    public void Load()
    {
        Saver.Load(this);
        AbilityCountChanged?.Invoke(_value);
    }
}
