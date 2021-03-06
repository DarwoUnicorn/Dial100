using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementView : MonoBehaviour
{
    [SerializeField]
    private Transform _filler;
    [SerializeField]
    private Achievement _achievement;
    [SerializeField]
    private List<Image> _levels = new List<Image>();
    [SerializeField]
    private Sprite _filledStar;
    [SerializeField]
    private TMP_Text _text;

    public void OnPointsChanged(float fillPercent)
    {
        _filler.localScale = new Vector3(fillPercent, 1, 1);
        int level = _achievement.Level;
        if(_achievement.Level == _achievement.MaxLevel)
        {
            level--;
        }
        _text.text = $"{ _achievement.Points }/{ _achievement.Conditions[level] }";
    }

    public void OnLevelChanged(int level)
    {
        for(int i = 0; i < level; i++)
        {
            _levels[i].sprite = _filledStar;
        }
        if(level == _achievement.MaxLevel)
        {
            level--;
        }
        _text.text = $"{ _achievement.Points }/{ _achievement.Conditions[level] }";
    }
}
