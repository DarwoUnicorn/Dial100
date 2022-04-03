public class TimerRestoreAbility : Ability
{
    public override void Use()
    {
        base.Use();
        AbilityUsed?.Invoke();
    }
}
