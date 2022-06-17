using UnityEngine;
using TMPro;

public class AbilityCountView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public void OnAbilityCountChanged(int count)
    {
        if(count == 0)
        {
            _text.text = "+";
            return;
        }
        _text.text = count.ToString();
    }
}
