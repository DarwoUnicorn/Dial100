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
    private UnityEvent Loaded = new UnityEvent();

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
            return;
        }
        Loaded?.Invoke();
    }

    public void Save()
    {
        Saver.Save(this);
    }

    public void Load()
    {
        PlayerName temp = gameObject.AddComponent<PlayerName>();
        if(Saver.Load(temp, _id))
        {
            _name = temp.Name;
        }
        Destroy(temp);
    }

    #region MonoBehaviour

    private void Start()
    {
        Load();
        CheckName();
        NameChanged?.Invoke();
    }

    #endregion
}
