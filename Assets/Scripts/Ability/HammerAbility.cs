public class HammerAbility : Ability
{
    public override void Use()
    {
        base.Use();
        AbilityUsed?.Invoke();
    }
}
