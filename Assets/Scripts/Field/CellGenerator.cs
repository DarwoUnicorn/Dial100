using UnityEngine;
using UnityEngine.Events;

public class CellGenerator : MonoBehaviour
{
    [SerializeField]
    private UnityEvent MaxStartCellValueReset = new UnityEvent();

    private static CellGenerator _instance;

    private int _minStartCellValue = 1;
    private int _maxStartCellValue = 20;
    private int _generationsBeforeReset;

    public static int Generate()
    { 
        if(_instance == null)
        {
            throw new System.NullReferenceException("There must be a CellGenerator on the scene");
        }
        int temp = Random.Range(_instance._minStartCellValue, _instance._maxStartCellValue + 1);
        if(_instance._generationsBeforeReset != 0)
        {
            _instance._generationsBeforeReset--;
            if(_instance._generationsBeforeReset == 0)
            {
                _instance.ResetMaxStartCellValue();
            }
        }
        return temp;
    }

    public void DescreaseMaxStartValue()
    {
        _instance._maxStartCellValue = 10;
        _instance._generationsBeforeReset = 10;
    }

    public void ResetMaxStartCellValue()
    {
        _instance._maxStartCellValue = 20;
        _instance.MaxStartCellValueReset?.Invoke();
    }
    
    #region "MonoBehaviour"

    private void Start()
    {
        if(_instance == null)
        {
            _instance = this;   
            return;
        }
        if(_instance != this)
        {
            throw new SingletonException("There should only be one CellGenerator");
        }
    }

    #endregion
}
