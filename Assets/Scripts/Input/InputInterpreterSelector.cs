using UnityEngine;

public class InputInterpreterSelector : MonoBehaviour
{
    [SerializeField]
    private InputInterpreter startInputInterpreter; 

    private InputInterpreter activeInputInterpreter;

    public void SelectInputInterpreter(InputInterpreter inputInterpreter)
    {
        if(inputInterpreter == null)
        {
            throw new System.ArgumentNullException(inputInterpreter.ToString());
        }
        if(activeInputInterpreter != null)
        {
            DisableInterpreter(activeInputInterpreter);
        }
        activeInputInterpreter = inputInterpreter;
        EnableInterpreter(activeInputInterpreter);
    }

    private void Start()
    {
        if(startInputInterpreter == null)
        {
            throw new System.NullReferenceException(startInputInterpreter.ToString());
        }
        DisableAllInterpreter();
        activeInputInterpreter = startInputInterpreter;
        EnableInterpreter(activeInputInterpreter);
    }

    private void EnableInterpreter(InputInterpreter interpreter)
    {
        interpreter.enabled = true;
    }

    private void DisableInterpreter(InputInterpreter interpreter)
    {
        interpreter.enabled = false;
    }

    private void DisableAllInterpreter()
    {
        InputInterpreter[] interpreters;
        interpreters = FindObjectsOfType<InputInterpreter>();
        foreach(var item in interpreters)
        {
            DisableInterpreter(item);
        }
    }
}
