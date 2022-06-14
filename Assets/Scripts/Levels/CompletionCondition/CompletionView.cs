using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletionView : MonoBehaviour
{
    [SerializeField]
    private Image _button;
    [SerializeField]
    private List<Image> _stars;

    [SerializeField]
    private Sprite _completedStar;
    [SerializeField]
    private Sprite _completedButton;

    public void SetCompletionStar(int stars)
    {
        for(int i = 0; i <= stars; i++)
        {
            _stars[i].sprite = _completedStar;
        }
        if(stars == 2)
        {
            _button.sprite = _completedButton;
        }
    }
}
