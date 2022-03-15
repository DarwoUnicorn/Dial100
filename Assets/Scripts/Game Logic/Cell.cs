using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private GameObject _parent;

    public TextMeshProUGUI Text => _text;
    public GameObject Parent => _parent;
    public Vector2Int Coordinates { get; private set; }
    public int Value { get; private set; }
    public bool IsComplete { get { return Value == 100; } }

    public void GenerateValue(int minValue, int maxValue)
    {
        Value = Random.Range(minValue, maxValue + 1);
    }

    public bool TryIncreaseValue(Cell other)
    {
        if(other == null || Value + other.Value > 100)
        {
            return false;
        }
        Value += other.Value;
        return true;
    }

    public bool TryChangeCoordinates(Vector2Int newCoordinates)
    {
        if(newCoordinates.x < 0 || newCoordinates.y < 0)
        {
            Debug.Log("Coordinates can't be less than 0");
            return false;
        }
        Coordinates = newCoordinates;
        return true;
    }

    public bool TryChangeCoordinates(int x, int y)
    {
        return TryChangeCoordinates(new Vector2Int(x, y));
    }

    public void SetParent(GameObject cell)
    {
        transform.SetParent(cell.transform);
        _parent = cell;
    }
}
