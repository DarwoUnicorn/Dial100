using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class InputInterpreter : MonoBehaviour
{
    [SerializeField]
    protected GraphicRaycaster Raycaster;

    protected bool IsActive;
}
