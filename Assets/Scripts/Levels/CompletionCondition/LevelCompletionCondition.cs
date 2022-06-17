using UnityEngine;
using UnityEngine.Events;

public abstract class LevelCompletionCondition : MonoBehaviour, IPersistent
{
    [SerializeField]
    private UnityEvent LevelComplete = new UnityEvent();

    [SerializeField]
    protected CompletionView CompletionView;
    
    [SerializeField]
    private int _stars;
    [SerializeField]
    private LevelId _levelId;
    [SerializeField]
    private bool IsCompleted;

    public string Id => _levelId.Id + "CompletionCondition";

    protected void Complete(int stars)
    {
        if(_stars >= stars)
        {
            return;
        }
        if(IsCompleted == false)
        {
            IsCompleted = true;
            LevelComplete?.Invoke();
        }
        _stars = stars;
        CompletionView.SetCompletionStar(stars);
        Save();
    }

    public abstract void CheckCondition(int value);

    public void Load()
    {
        LevelCompletionCondition temp = (LevelCompletionCondition)gameObject.AddComponent(this.GetType());
        if(Saver.Load(temp, Id))
        {
            IsCompleted = temp.IsCompleted;
            _stars = temp._stars;
            if(IsCompleted && _stars == 0)
            {
                Complete(1);
                return;
            }
            CompletionView.SetCompletionStar(_stars);
        }
        Destroy(temp);
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
