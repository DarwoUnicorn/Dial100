using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Achievement : MonoBehaviour, IPersistent
{
    [SerializeField]
    private UnityEvent<float> PointsChanged = new UnityEvent<float>();
    [SerializeField]
    private UnityEvent<int> LevelChanged = new UnityEvent<int>();

    [SerializeField]
    private int _maxLevel;
    [SerializeField]
    private int _level;
    [SerializeField]
    private List<int> _conditions = new List<int>();
    [SerializeField]
    private int _points;
    [SerializeField]
    private string _id;

    public string Id => _id;
    public int Points => _points;
    public int Level => _level;
    public IReadOnlyList<int> Conditions => _conditions;

    public void IncreasePoints(int points)
    {
        if(_level == _maxLevel)
        {
            return;
        }
        _points += points;
        CheckPoints();
        CallPointChanged();
        Save();
    }

    public void SetPoints(int points)
    {
        if(_level == _maxLevel)
        {
            return;
        }
        if(points < _points)
        {
            return;
        }
        _points = points;
        CheckPoints();
        CallPointChanged();
        Save();
    }

    public void Load()
    {
        Saver.Load(this);
    }

    public void Save()
    {
        Saver.Save(this);
    }

    private void CheckPoints()
    {
        if(_points >= _conditions[_level])
        {
            _level++;
            LevelChanged?.Invoke(_level);
        }
    }

    public void CallPointChanged()
    {
        int condition = _conditions[_level];
        int points = _points;
        if(_level > 0)
        {
            condition -= _conditions[_level - 1];
            points -= _conditions[_level - 1];
        }
        PointsChanged?.Invoke((float)points / condition);
    }

    private void Start()
    {
        Load();        
        CallPointChanged();
        LevelChanged?.Invoke(_level);
    }
}