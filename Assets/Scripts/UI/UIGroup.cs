using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class UIGroup : MonoBehaviour
{
    public CanvasGroup Group { get; private set; }

    private void Start()
    {
        Group = GetComponent<CanvasGroup>();
    }
}
