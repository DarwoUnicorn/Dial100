using UnityEngine;
using UnityEngine.Events;

public class HammerAbility : Ability
{
    [SerializeField]
    private UnityEvent Deactivated = new UnityEvent();

    private bool IsUsed;

    public override void Use()
    {
        if(IsUsed == false)
        {
            Activate();
            return;
        }
        Deactivate();
    }

    public void Deactivate()
    {
        if(IsUsed == true)
        {
            IsUsed = false;
            Deactivated?.Invoke();
            IncreaseAbilityCount(1);
        }
    }

    public void OnUsingHammer()
    {
        IsUsed = false;
    }

    private void Activate()
    {
        if(Count == 0)
        {
            return;
        }
        base.Use();
        IsUsed = true;
    }
}
