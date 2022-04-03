public class DescreaseMaxStartValueAbility : Ability
{
    public override void Use()
    {
        base.Use();
        AbilityUsed?.Invoke();
    }
}
