using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    private CellData _data;
    
    public TextMeshProUGUI Text => _text;
    public Transform Parent => transform.parent;
    public int Value => _data.Value;
    public bool IsComplete => _data.IsComplete;
    public bool IsCreated { get; private set; }

    public bool TryIncreaseValue(Cell other)
    {
        return _data.TryIncreaseValue(other._data);
    }

    public void Generate()
    {
        if(_data == null)
        {
            _data = new CellData();
        }
        _data.Generate();
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

    #region MonoBehaviour

    private void LateUpdate()
    {
        if(IsCreated == true)
        {
            IsCreated = false;
        }
    }

    #endregion
}
