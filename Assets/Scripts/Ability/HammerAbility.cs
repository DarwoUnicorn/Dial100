using UnityEngine;
using UnityEngine.Events;

public class HammerAbility : Ability
{
    [SerializeField]
    private UnityEvent Deactivated = new UnityEvent();

    private bool _isUsed;

    public void OnClick()
    {
        if(_isUsed)
        {
            Deactivate();
            return;
        }
        Use();
    }

    public override void Use()
    {
        if(Count == 0)
        {
            AbilityOver?.Invoke();
            return;
        }
        _isUsed = true;
        AbilityUsed?.Invoke();
    }

    public void OnUsingHammer()
    {
        Deactivate();
        _abilityCount.OnAbilityUsed();
    }

    private void Deactivate()
    {
        _isUsed = false;
        Deactivated?.Invoke();
    }
}
