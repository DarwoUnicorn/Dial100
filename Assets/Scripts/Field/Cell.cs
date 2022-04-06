using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public TextMeshProUGUI Text => _text;
    public Transform Parent => transform.parent;
    public CellData Data { get; private set; }
    public bool IsCreated { get; private set; }

    public void Generate()
    {
        if(Data == null)
        {
            Data = new CellData();
        }
        Data.Generate();
        IsCreated = true;
    }

    public void Swap(Cell other)
    {
        if(other == null)
        {
            throw new System.ArgumentNullException(other.ToString());
        }
        Transform tempParent = Parent;
        transform.SetParent(other.Parent);
        other.transform.SetParent(tempParent);
    }

    #region "MonoBehaviour"

    private void LateUpdate()
    {
        if(IsCreated == true)
        {
            IsCreated = false;
        }
    }

    #endregion
}
