using UnityEngine;
using TMPro;

public class Cell
{
    public CellData _cellData { get; private set; }
    public TextMeshProUGUI _text { get; private set; }
    public GameObject Parent => _cellData.transform.parent.gameObject;
    public bool IsActive { get; private set; }

    public Cell(GameObject cell)
    {
        _cellData = cell.GetComponent<CellData>();
        _text = cell.GetComponent<TextMeshProUGUI>();
        if(_cellData != null)
        {
            SetParent(cell);
            IsActive = true;
        }
    }

    public void SetParent(GameObject parent)
    {
        _cellData.transform.SetParent(parent.transform);
    }
}
