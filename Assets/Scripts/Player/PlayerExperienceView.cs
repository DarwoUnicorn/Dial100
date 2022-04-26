using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerExperienceView : MonoBehaviour
{
    [SerializeField]
    private PlayerLevel _level;
    [SerializeField]
    private List<Transform> _fillers = new List<Transform>();

    public void OnExperienceChanged()
    {
        float fill = (float)_level.Experience / _level.ExperienceToNextLevel;
        for(int i = 0; i < _fillers.Count; i++)
        {
            _fillers[i].localScale = new Vector3(fill, 1, 1);
        }
    }

    private void Start()
    {
        OnExperienceChanged();
    }
}
