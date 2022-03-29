using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private Score _score;
    [SerializeField]
    private TextMeshProUGUI _text;

    public void OnPointsChanged()
    {
        _text.text = _score.Points.ToString();
    }
}
