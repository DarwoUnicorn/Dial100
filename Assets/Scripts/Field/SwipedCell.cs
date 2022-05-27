using UnityEngine;
using TMPro;

public class SwipedCell : MonoBehaviour
{
    [SerializeField]
    private Transform _cell;
    [SerializeField]
    private TMP_Text _cellText;
    [SerializeField]
    private float _step;

    private Vector2 _targetPosition;

    public void OnMove(Cell firstSelected, Cell other)
    {
        _cell.position = firstSelected.transform.position;
        _cellText.alpha = 1;
        _cellText.text = firstSelected.Value.ToString();
        _targetPosition = other.transform.position;
    }

    private void Update()
    {
        if((Vector2)_cell.position != _targetPosition)
        {
            _cell.position = Vector3.MoveTowards(_cell.position, _targetPosition, _step);
        }
        if(_cellText.alpha != 0)
        {
            _cellText.alpha -= 0.1f;
        }
    }
}
