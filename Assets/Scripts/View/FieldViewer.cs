using System.Collections.Generic;
using UnityEngine;

public class FieldViewer : MonoBehaviour
{
    [SerializeField]
    private float _moveStep;
    [SerializeField]
    private Field _field;

    private List<List<GameObject>> cellParents;
    private List<Cell> _objectsForMove = new List<Cell>();

    public void SetCellParents(List<List<GameObject>> field)
    {
        cellParents = field;
    }

    public void OnFieldChanged()
    {
        float distanceBetweenCells = Vector2.Distance(cellParents[0][0].transform.position,
                                                      cellParents[0][1].transform.position);
        for(int i = 0; i < _field.Cells.Count; i++)
        {
            int newCellsCount = 0;
            foreach(var cell in _field.Cells[i])
            {
                if(cell == null)
                {
                    continue;
                }
                cell.Text.text = cell.Data.Value.ToString();
                if(cell.State == Cell.MotionState.Idle)
                {
                    continue;
                }
                if(cell.State == Cell.MotionState.Created)
                {
                    newCellsCount++;
                    cell.transform.position = cellParents[i][cellParents[i].Count - 1].transform.position + 
                        Vector3.up * (distanceBetweenCells * newCellsCount);
                    cell.SetFalls();
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