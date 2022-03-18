using UnityEngine;
using TMPro;

public class Cell
{
    public CellData CellData { get; private set; }
    public TextMeshProUGUI Text { get; private set; }
    public GameObject Parent => _cellData.transform.parent.gameObject;
    public bool IsActive { get; private set; }

    public Cell(GameObject cell)
    {
        CellData = cell.GetComponent<CellData>();
        Text = cell.GetComponent<TextMeshProUGUI>();
        if(CellData != null)
        {
            SetParent(cell);
            IsActive = true;
        }
    }

    public void SetParent(GameObject parent)
    {
        CellData.transform.SetParent(parent.transform);
    }
}
