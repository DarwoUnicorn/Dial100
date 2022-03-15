using System.Collections.Generic;
using UnityEngine;

public class FieldViewer : MonoBehaviour
{
    [SerializeField]
    private float _moveStep;
    [SerializeField]
    private Field _field;

    private List<Transform> _objectsForMove = new List<Transform>();

    public void UpdateFieldView()
    {
        foreach(var column in _field.CellsData)
        {
            int oversize;
            foreach(var item in column)
            {
                if(IsValideParent(item.transform.parent, item.Coordinates) == false)
                {
                    ChangeParent(item, _field.Cells[item.Coordinates.x][item.Coordinates.y]);
                }
            }
        }
    }

    private void ChangeParent(CellData cellData, GameObject newParent)
    {
        cellData.SetParent(newParent);
        if(_objectsForMove.Contains(cellData.transform) == false)
        {
            _objectsForMove.Add(newParent.transform);
        }
    }

    private bool IsValideParent(Transform parent, Vector2Int coordinates)
    {
        return parent == _field.Cells[coordinates.x][coordinates.y];
    }

    private void Update()
    {
        foreach(var item in _objectsForMove)
        {
            item.localPosition = Vector3.MoveTowards(item.localPosition, Vector3.zero, _moveStep); 
        }
    }
}