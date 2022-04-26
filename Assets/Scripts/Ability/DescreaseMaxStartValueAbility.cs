using UnityEngine;
using UnityEngine.Events;

public class DescreaseMaxStartValueAbility : Ability
{
    [SerializeField]
    private UnityEvent AbilityEnded = new UnityEvent();

    public void AbilityEnd()
    {
        AbilityEnded?.Invoke();
    }
}
