using UnityEngine;
using UnityEngine.Events;

public class LevelHighScore : MonoBehaviour, IPersistent
{
    [SerializeField]
    private UnityEvent<int> ScoreChanged = new UnityEvent<int>();

    [SerializeField]
    private LevelId _levelId;
    [SerializeField]
    private int _value;

    public int Value => _value;

    public string Id => _levelId.Id + "LevelScore";

    public void SetHighScore(int score)
    {
        if(score > _value)
        {
            _value = score;
            UpdateScore();
            Save();
        }
    }

    public void UpdateScore()
    {   
        ScoreChanged?.Invoke(_value);
    }

    public void Load()
    {
        Saver.Load(this);
        UpdateScore();
    }

    public void Save()
    {
        Saver.Save(this);
    }

    private void Start()
    {
        Load();
    }
}
