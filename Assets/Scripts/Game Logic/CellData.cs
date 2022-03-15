using UnityEngine;
using TMPro;

public class CellData : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public TextMeshProUGUI Text => _text;
    public Vector2Int Coordinates { get; private set; }
    public int Value { get; private set; }
    public bool IsComplete { get { return Value == 100; } }

    public void GenerateValue(int minValue, int maxValue)
    {
        Value = Random.Range(minValue, maxValue + 1);
    }

    public bool TryIncreaseValue(CellData other)
    {
        if(other == null || Value + other.Value > 100)
        {
            return false;
        }
        Value += other.Value;
        return true;
    }

    public void SetCoordinates(Vector2Int newCoordinates)
    {
        Coordinates = newCoordinates;
    }

    public void SetCoordinates(int x, int y)
    {
        SetCoordinates(new Vector2Int(x, y));
    }

    public void SetParent(GameObject cell)
    {
        transform.SetParent(cell.transform);
    }
}
