using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    [SerializeField]
    private List<Achievement> _list = new List<Achievement>();

    public IReadOnlyList<Achievement> List => _list;
}
