using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public void OnPointsChanged(int points)
    {
        _text.text = points.ToString();
    }
}
