using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerName : IPersistent
{
    public enum SetPlayerNameState
    {
        IncorrectName,
        CorrectName,
    }

    [SerializeField]
    private UnityEvent NameChanged = new UnityEvent();
    [SerializeField]
    private UnityEvent NameIsEmpty = new UnityEvent();

    [SerializeField]
    private string _name;
    [SerializeField]
    private string _id;

    public string Name => _name;
    public string Id => _id;

    public SetPlayerNameState SetName(string name)
    {
        if(name.Length < 4)
        {
            return SetPlayerNameState.IncorrectName;
        }
        _name = name;
        NameChanged?.Invoke();
        Save();
        return SetPlayerNameState.CorrectName;
    }

    public void CheckName()
    {
        if(_name == "")
        {
            NameIsEmpty?.Invoke();
        }
    }

    public void Save()
    {
        Saver.Save(this, _id);
    }

    public void Load()
    {
        Saver.Load(this, this.GetType(), _id);
        NameChanged?.Invoke();
    }
}
