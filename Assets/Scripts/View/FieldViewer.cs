using System.Collections.Generic;
using UnityEngine;

public class FieldViewer : MonoBehaviour
{
    [SerializeField]
    private float _moveStep;
    [SerializeField]
    private Field _field;

    private List<Cell> _objectsForMove = new List<Cell>();

    public void OnFieldChanged()
    {
        float distance = Vector2.Distance(_field.Cells[0][_field.Cells.Count - 1].Parent.position,
                                          _field.Cells[0][_field.Cells.Count - 2].Parent.position);
        for(int i = 0; i < _field.Cells.Count; i++)
        {
            int newCellsCount = 0;
            foreach(var cell in _field.Cells[i])
            {
                cell.Text.text = cell.Data.Value.ToString();
                if(cell.State == Cell.MotionState.Idle)
                {
                    continue;
                }
                if(cell.State == Cell.MotionState.Created)
                {
                    newCellsCount++;
                    cell.transform.position = _field.Cells[i][_field.Cells.Count - 1].Parent.position + 
                        Vector3.up * (distance * newCellsCount);
                }
                if(_objectsForMove.Contains(cell) == false)
                {
                    _objectsForMove.Add(cell);
                }
            }
        }
    }

    private void Update()
    {
        for(int i = _objectsForMove.Count - 1; i >= 0; i--)
        {
            _objectsForMove[i].transform.localPosition = 
                Vector3.MoveTowards(_objectsForMove[i].transform.localPosition, Vector3.zero, _moveStep);
            if(_objectsForMove[i].transform.localPosition == Vector3.zero)
            {
                _objectsForMove[i].SetIdle();
                _objectsForMove.RemoveAt(i);
            } 
        }
    }
}