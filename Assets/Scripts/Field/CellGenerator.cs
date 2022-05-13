using UnityEngine;
using UnityEngine.Events;

public class CellGenerator : MonoBehaviour
{
    [SerializeField]
    private UnityEvent MaxStartCellValueReset = new UnityEvent();

    public static CellGenerator Instance { get; private set; }

    private int _minStartCellValue = 1;
    private int _maxStartCellValue = 20;
    private int _generationsBeforeReset;

    public int Generate()
    { 
        int temp = Random.Range(_minStartCellValue, _maxStartCellValue + 1);
        if(_generationsBeforeReset != 0)
        {
            _generationsBeforeReset--;
            if(_generationsBeforeReset == 0)
            {
                ResetMaxStartCellValue();
            }
        }
        return temp;
    }

    public void DescreaseMaxStartValue()
    {
        _maxStartCellValue = 10;
        _generationsBeforeReset = 10;
    }

    public void ResetMaxStartCellValue()
    {
        _maxStartCellValue = 20;
        MaxStartCellValueReset?.Invoke();
    }
    
    #region MonoBehaviour

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;   
            return;
        }
        if(Instance != this)
        {
            throw new SingletonException("There should only be one CellGenerator");
        }
    }

    #endregion
}
