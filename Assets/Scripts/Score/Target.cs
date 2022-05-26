using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    [SerializeField]
    private GameObject _scoreTarget;
    [SerializeField]
    private TMP_Text _scoreTargetText;
    [SerializeField]
    private GameObject _cellTarget;
    [SerializeField]
    private TMP_Text _cellTargetText;

    public void OnLevelChanged(LevelParameters parameters)
    {
        ScoreCompletionCondition scoreTemp = parameters.CompletionCondition as ScoreCompletionCondition;
        FullCellCompletionCondition cellTemp = parameters.CompletionCondition as FullCellCompletionCondition;
        if(scoreTemp != null)
        {
            _scoreTarget.SetActive(true);
            _scoreTargetText.text = scoreTemp.RequiredLevel.ToString();
            _cellTarget.SetActive(false);
        }
        else if(cellTemp != null)
        {
            _scoreTarget.SetActive(false);
            _cellTargetText.text = cellTemp.RequiredFullCells.ToString();
            _cellTarget.SetActive(true);
        }
    }
}
