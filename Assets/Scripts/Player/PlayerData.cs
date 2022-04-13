using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private PlayerName _name = new PlayerName();
    [SerializeField]
    private PlayerLevel _level = new PlayerLevel();

    public string Name => _name.Name;
    public PlayerLevel Level => _level;

    public void AddExperience(int experience)
    {
        _level.AddExperience(experience);
    }

    public PlayerName.SetPlayerNameState SetName(string name)
    {
        return _name.SetName(name);
    }

    private void Start()
    {
        _name.Load();
        _name.CheckName();
    }
}
