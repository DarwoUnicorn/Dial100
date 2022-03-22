using UnityEngine;

public class CellData
{
    public int Value { get; private set; }
    public bool IsComplete { get { return Value == 100; } }

    public void SetValue(int value)
    {
        if(value < 1 || value > 100)
        {
            throw new System.ArgumentException("Value must be between 1 and 100");
        }
        Value = value;
    }

    public bool TryIncreaseValue(CellData other)
    {
        if(other == null)
        {
            throw new System.ArgumentNullException();
        }
        if(Value + other.Value > 100)
        {
            return false;
        }
        Value += other.Value;
        return true;
    }
}
