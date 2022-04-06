using UnityEngine;
using UnityEngine.UI;

public abstract class InputInterpreter : MonoBehaviour
{
    [SerializeField]
    protected GraphicRaycaster Raycaster;

    protected bool IsActive;
}
