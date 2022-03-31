using UnityEngine;

public abstract class Abillity : MonoBehaviour
{
    [SerializeField]
    private int _count;

    public int Count => _count;

    public virtual void Use()
    {
        if(_count <= 0)
        {
            throw new System.InvalidOperationException("Cannot use the ability, as their count is 0");
        }
        _count--;
    }

    public void IncreaseAbillityCount(int count)
    {
        if(count < 1)
        {
            throw new System.ArgumentException("Count must be greater than 0");
        }
        _count += count;
    }
}
