using UnityEngine;

public class UIScaller : MonoBehaviour
{
    [SerializeField]
    private RectTransform _pages;
    [SerializeField]
    private RectTransform _windows;

    private void Start()
    {
        if(Camera.main.aspect > 0.6f)
        {
            _pages.sizeDelta = new Vector2(_pages.rect.x - _pages.rect.y * 0.6f, _pages.sizeDelta.y);
            _windows.sizeDelta = new Vector2(_windows.rect.x - _windows.rect.y * 0.55f, _windows.sizeDelta.y);
        }
    }

}
