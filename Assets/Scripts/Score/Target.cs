using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    [SerializeField]
    private GameObject _scoreTarget;
    [SerializeField]
    private TMP_Text _targetText;
    [SerializeField]
    private GameObject _cellTarget;

    public void OnLevelChanged(LevelParameters parameters)
    {
        ScoreCompletionCondition scoreTemp = parameters.CompletionCondition as ScoreCompletionCondition;
        FullCellCompletionCondition cellTemp = parameters.CompletionCondition as FullCellCompletionCondition;
        if(scoreTemp != null)
        {
            _scoreTarget.SetActive(true);
            _targetText.text = scoreTemp.RequiredLevel.ToString();
            _cellTarget.SetActive(false);
        }
        else if(cellTemp != null)
        {
            _scoreTarget.SetActive(false);
            _targetText.text = cellTemp.RequiredFullCells.ToString();
            _cellTarget.SetActive(true);
        }
    }
}
