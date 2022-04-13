using UnityEngine;
using UnityEngine.Events;

public abstract class Ability : MonoBehaviour
{
    [SerializeField]
    protected UnityEvent AbilityUsed = new UnityEvent();
    [SerializeField]
    protected UnityEvent AbilityOver = new UnityEvent();

    [SerializeField]
    protected AbilityCount _abilityCount = new AbilityCount();

    public int Count => _abilityCount.Value;

    public virtual void Use()
    {
        if(Count == 0)
        {
            AbilityOver?.Invoke();
            return;
        }
        AbilityUsed?.Invoke();
        _abilityCount.OnAbilityUsed();
    }

    public void IncreaseAbilityCount(int value)
    {
        _abilityCount.IncreaseAbilityCount(value);
    }

    #region "MonoBehaviour"

    private void Start()
    {
        _abilityCount.Load();
    }

    #endregion
}
