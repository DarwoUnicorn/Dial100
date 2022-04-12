using UnityEngine;

public class ExitAppButton : IButton
{
    public override void Action()
    {
        Application.Quit();
    }
}