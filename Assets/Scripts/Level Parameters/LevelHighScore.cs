using UnityEngine;

[System.Serializable]
public class LevelHighScore : IPersistent
{
    [SerializeField]
    private int _value;
    [SerializeField]
    private string _id;

    public int Value => _value;
    public string Id => _id;

    public void Save()
    {
        Saver.Save(this, _id);
    }

    public void Load()
    {
        Saver.Load(this, this.GetType(),_id);
    }

    public void SetHighScore(int score)
    {
        if(score > _value)
        {
            _value = score;
        }
    }

    private void Start()
    {
        Load();
    }
}
