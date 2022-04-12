using System.Collections.Generic;
using UnityEngine;

public class PlayerExperienceView : MonoBehaviour
{
    [SerializeField]
    private PlayerLevel _playerLevel;
    [SerializeField]
    private List<Transform> _fillers = new List<Transform>();

    public void OnExperienceChanged()
    {
        float fill = (float)_playerLevel.Experience / _playerLevel.ExperienceToNextLevel;
        Debug.Log(_playerLevel.Experience);
        Debug.Log(_playerLevel.ExperienceToNextLevel);
        Debug.Log(fill);
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
