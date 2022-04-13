using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    [SerializeField]
    private List<LevelParameters> _list  = new List<LevelParameters>();

    public IReadOnlyList<LevelParameters> List => _list;
}
