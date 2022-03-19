using UnityEngine;
using TMPro;

public class Cell
{
    public enum ChangeState
    {
        Idle,
        Created,
        Fall,
    }

    public ChangeState State;

    public CellData Data { get; private set; }
    public TextMeshProUGUI Text { get; private set; }
    public bool IsActive { get; private set; }
    public GameObject Parent => Data.transform.parent.gameObject;

    public Cell(GameObject cell)
    {
        Data = cell.GetComponent<CellData>();
        Text = cell.GetComponent<TextMeshProUGUI>();
        if(Data != null)
        {
            SetParent(cell);
            IsActive = true;
        }
    }

    public void SetParent(GameObject parent)
    {
        Data.transform.SetParent(parent.transform);
    }
}
