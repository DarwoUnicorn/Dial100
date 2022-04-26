using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerName : MonoBehaviour, IPersistent
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
    private string _id;
    [SerializeField]
    private string _name;

    public string Id => _id;
    public string Name => _name;

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
        Saver.Save(this);
    }

    public void Load()
    {
        UnityEvent temp1 = NameChanged;
        UnityEvent temp2 = NameIsEmpty;
        Saver.Load(this);
        NameChanged = temp1;
        NameIsEmpty = temp2;
    }

    #region  "MonoBehaviour"

    private void Start()
    {
        Load();
        CheckName();
        NameChanged?.Invoke();
    }

    #endregion
}
