using UnityEngine;

public class ButtonLanguage : MonoBehaviour
{
    [SerializeField]
    private Language _language;

    public Language Language => _language;
}
