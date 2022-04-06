using UnityEngine;
using UnityEngine.Events;

public abstract class Ability : MonoBehaviour
{
    [SerializeField]
    protected UnityEvent AbilityUsed = new UnityEvent();
    [SerializeField]
    protected UnityEvent AbilityOver = new UnityEvent();
    [SerializeField]
    protected UnityEvent<int> AbilitiCountChanged = new UnityEvent<int>();

    [SerializeField] [Min(0)]
    private int _count;

    public int Count => _count;

    public virtual void Use()
    {
        if(_count == 0)
        {
            AbilityOver?.Invoke();
            return;
        }
        AbilityUsed?.Invoke();
        AbilitiCountChanged?.Invoke(--_count);
    }

    public void IncreaseAbilityCount(int count)
    {
        if(count < 1)
        {
            throw new System.ArgumentException("Count must be greater than 0");
        }
        _count += count;
        AbilitiCountChanged?.Invoke(_count);
    }

    #region "MonoBehaviour"

    private void Start()
    {
        AbilitiCountChanged?.Invoke(_count);
    }

    #endregion
}
