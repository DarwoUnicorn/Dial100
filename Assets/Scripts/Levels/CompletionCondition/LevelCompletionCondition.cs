using UnityEngine;
using UnityEngine.Events;

public abstract class LevelCompletionCondition : MonoBehaviour, IPersistent
{
    [SerializeField]
    private UnityEvent LevelComplete = new UnityEvent();
    [SerializeField]
    private UnityEvent Loaded = new UnityEvent();

    [SerializeField]
    private bool IsCompleted;
    [SerializeField]
    private LevelId _levelId;

    public string Id => _levelId.Id + "CompletionCondition";

    protected void Complete()
    {
        if(IsCompleted)
        {
            return;
        }
        IsCompleted = true;
        LevelComplete?.Invoke();
        Save();
    }

    public abstract void CheckCondition(int value);

    public void Load()
    {
        Saver.Load(this);
        if(IsCompleted)
        {
            Loaded?.Invoke();
        }
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
