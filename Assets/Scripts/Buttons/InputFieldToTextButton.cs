using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class InputFieldToTextButton : IButton
{
    [SerializeField]
    private UnityEvent IncorrectInput = new UnityEvent();
    [SerializeField]
    private UnityEvent NameSet = new UnityEvent();

    [SerializeField]
    private PlayerName _name;
    [SerializeField]
    private TMP_Text _text;

    public override void Action()
    {
        if(_name.SetName(_text.text) == PlayerName.SetPlayerNameState.IncorrectName)
        {
            IncorrectInput?.Invoke();
            return;
        }
        NameSet?.Invoke();
    }
}
