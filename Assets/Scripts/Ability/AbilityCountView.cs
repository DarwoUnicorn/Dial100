using UnityEngine;
using TMPro;

public class AbilityCountView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public void OnAbilityCountChanged(int count)
    {
        _text.text = count.ToString();
    }
}
