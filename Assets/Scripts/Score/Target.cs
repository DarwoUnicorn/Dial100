using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    [SerializeField]
    private GameObject _scoreTarget;
    [SerializeField]
    private List<TMP_Text> _targetText;
    [SerializeField]
    private GameObject _cellTarget;

    public void OnLevelChanged(LevelParameters parameters)
    {
        ScoreCompletionCondition scoreTemp = parameters.CompletionCondition as ScoreCompletionCondition;
        FullCellCompletionCondition cellTemp = parameters.CompletionCondition as FullCellCompletionCondition;
        if(scoreTemp != null)
        {
            _scoreTarget.SetActive(true);
            _targetText[0].text = scoreTemp.RequiredScore[0].ToString();
            _targetText[1].text = scoreTemp.RequiredScore[1].ToString();
            _targetText[2].text = scoreTemp.RequiredScore[2].ToString();
            _cellTarget.SetActive(false);
        }
        else if(cellTemp != null)
        {
            _scoreTarget.SetActive(false);
            _targetText[0].text = cellTemp.RequiredFullCells[0].ToString();
            _targetText[1].text = cellTemp.RequiredFullCells[1].ToString();
            _targetText[2].text = cellTemp.RequiredFullCells[2].ToString();
            _cellTarget.SetActive(true);
        }
    }
}
