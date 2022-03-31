using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class InputInterpreter : MonoBehaviour
{
    [SerializeField]
    protected GraphicRaycaster _graphicRaycaster;
    [SerializeField]
    protected EventSystem _eventSystem;
}
