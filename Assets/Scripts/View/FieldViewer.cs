using System.Collections.Generic;
using UnityEngine;

public class FieldViewer : MonoBehaviour
{
    [SerializeField]
    private float _moveStep;
    [SerializeField]
    private Field _field;

    private List<Transform> _objectsForMove = new List<Transform>();

    private void Update()
    {
        foreach(var item in _objectsForMove)
        {
            item.localPosition = Vector3.MoveTowards(item.localPosition, Vector3.zero, _moveStep); 
        }
    }
}