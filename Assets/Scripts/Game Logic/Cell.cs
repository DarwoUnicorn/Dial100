using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    public enum MotionState
    {
        Idle,
        Created,
        Falls,
    }

    [SerializeField]
    private TextMeshProUGUI _text;

    public TextMeshProUGUI Text => _text;
    public Transform Parent => transform.parent;
    public CellData Data { get; private set; }
    public MotionState State { get; private set; }

    public void Generate(int minValue, int maxValue)
    {
        if(Data == null)
        {
            Data = new CellData();
        }
        Data.SetValue(Random.Range(minValue, maxValue + 1));
        State = MotionState.Created;
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
        State = State != MotionState.Created ? MotionState.Falls : MotionState.Created;
        other.State = other.State != MotionState.Created ? MotionState.Falls : MotionState.Created;
    }

    public void SetIdle()
    {
        State = MotionState.Idle;
    }
}
