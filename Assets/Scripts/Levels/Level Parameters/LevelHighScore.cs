using UnityEngine;

[System.Serializable]
public class LevelHighScore
{
    [SerializeField]
    private int _value;

    public int Value => _value;

    public void SetHighScore(int score)
    {
        if(score > _value)
        {
            _value = score;
        }
    }
}
