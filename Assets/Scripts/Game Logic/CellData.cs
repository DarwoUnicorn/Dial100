using UnityEngine;
using TMPro;

public class CellData : MonoBehaviour
{
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
}
