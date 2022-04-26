using UnityEngine;

public class TimerParameters : MonoBehaviour
{
    [SerializeField] [Range(1, 100)]
    private float _maxTime = 1;

    public float MaxTime => _maxTime;
}
