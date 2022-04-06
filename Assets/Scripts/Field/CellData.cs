public class CellData
{
    public int Value { get; private set; }
    public bool IsComplete { get { return Value == 100; } }

    public void Generate()
    {
        Value = CellGenerator.Generate();
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
