using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class LevelHighScore
{
    [SerializeField]
    private UnityEvent<string> ScoreChanged = new UnityEvent<string>();

    [SerializeField]
    private int _value;

    public int Value => _value;

    public void SetHighScore(int score)
    {
        if(score > _value)
        {
            _value = score;
            UpdateScore();
        }
    }

    public void UpdateScore()
    {   
        ScoreChanged?.Invoke($"Score\n{_value}");
    }
}
