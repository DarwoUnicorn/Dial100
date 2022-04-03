using UnityEngine;
using UnityEngine.UI;

public abstract class GridResizer : MonoBehaviour
{
    [SerializeField]
    protected GridLayoutGroup GridGroup;
    [SerializeField]
    protected RectTransform Panel;

    protected Vector2 _previousSize = new Vector2();

    protected abstract void ChangeCellSize();

    protected virtual void Update()
    {
        if(_previousSize != Panel.rect.size)
        {
            ChangeCellSize();
            _previousSize = Panel.rect.size;
        }
    }
}
