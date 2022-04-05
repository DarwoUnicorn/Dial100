using UnityEngine;
using UnityEngine.Events;

public class HammerAbility : Ability
{
    [SerializeField]
    private UnityEvent Deactivated = new UnityEvent();

    private bool IsUsed;

    public override void Activate()
    {
        if(IsUsed == false)
        {
            if(Count == 0)
            {
                return;
            }
            base.Activate();
            IsUsed = true;
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
}
