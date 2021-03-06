using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> PointsChanged = new UnityEvent<int>();

    public int Points { get; private set; }

    public void IncreasePoints(int points)
    {
        if(points <= 0)
        {
            throw new System.ArgumentException("Points must be greater then 0");
        }
        Points += points;
        PointsChanged?.Invoke(Points);
    }  

    public void Reset()
    {
        Points = 0;
        PointsChanged?.Invoke(Points);
    }
}
