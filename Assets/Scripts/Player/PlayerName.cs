using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerName
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

    public string Name => _name;

    public SetPlayerNameState SetName(string name)
    {
        if(name.Length < 4)
        {
            return SetPlayerNameState.IncorrectName;
        }
        _name = name;
        NameChanged?.Invoke();
        return SetPlayerNameState.CorrectName;
    }

    public void CheckName()
    {
        if(_name == "")
        {
            NameIsEmpty?.Invoke();
        }
    }
}
