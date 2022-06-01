using System.Collections;
using UnityEngine;
using TMPro;

public class Notification : MonoBehaviour
{
    [SerializeField]
    private RectTransform _notificationPanel;
    [SerializeField]
    private TMP_Text _hammerCountText;
    [SerializeField]
    private TMP_Text _timeRestorerCountText;
    [SerializeField]
    private TMP_Text _decreaserCountText; 
    [SerializeField]
    private GameObject _hammerObject;
    [SerializeField]
    private GameObject _timeRestoreObject;
    [SerializeField]
    private GameObject _decreaserObject;

    private float _maxPosition;
    private float _minPosition;
    private bool _isShown;

    public void OnLevelUp()
    {
        _isShown = true;
    }

    public void SetHammerCount(int count)
    {
        _hammerCountText.text = "x" + count.ToString();
        _hammerObject.SetActive(true);
    }

    public void SetTimeRestorerCount(int count)
    {
        _timeRestorerCountText.text = "x" + count.ToString();
        _timeRestoreObject.SetActive(true);
    }

    public void SetDecreaserCount(int count)
    {
        _decreaserCountText.text = "x" + count.ToString();
        _decreaserObject.SetActive(true);
    }

    private void Start()
    {
        _maxPosition = _notificationPanel.anchoredPosition.y - _notificationPanel.rect.height; 
        _minPosition = 0;
    }

    private void Update()
    {
        if(_isShown && _notificationPanel.anchoredPosition.y != _maxPosition)
        {
            _notificationPanel.anchoredPosition = Vector3.MoveTowards(_notificationPanel.anchoredPosition, new Vector2(0, _maxPosition), 15f);
            if(_notificationPanel.anchoredPosition.y == _maxPosition)
            {
                StartCoroutine(DisableShown());
            }
            return;
        }
        else if(_isShown == false && _notificationPanel.anchoredPosition.y != _minPosition)
        {
            _notificationPanel.anchoredPosition = Vector3.MoveTowards(_notificationPanel.anchoredPosition, new Vector2(0, _minPosition), 15f);
            if(_notificationPanel.anchoredPosition.y == _minPosition)
            {
                _hammerObject.SetActive(false);
                _timeRestoreObject.SetActive(false);
                _decreaserObject.SetActive(false);
            }
            return;
        }
    }

    private IEnumerator DisableShown()
    {
        yield return new WaitForSeconds(2);
        _isShown = false;
    }
}
