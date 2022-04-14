using UnityEngine;

public class PlayerData : MonoBehaviour, IPersistent
{
    [SerializeField]
    private PlayerName _name = new PlayerName();
    [SerializeField]
    private PlayerLevel _level = new PlayerLevel();
    [SerializeField]
    private string _id;

    public string Name => _name.Name;
    public PlayerLevel Level => _level;
    public string Id => _id;

    public void AddExperience(int experience)
    {
        _level.AddExperience(experience);
        Save();
    }

    public PlayerName.SetPlayerNameState SetName(string name)
    {
        PlayerName.SetPlayerNameState state = _name.SetName(name);
        Save();
        return state;
    }

    public void Save()
    {
        Saver.Save(this);
    }

    public void Load()
    {
        Saver.Load(this);
    }

    private void Start()
    {
        Load();
        _name.CheckName();
    }
}
