using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLevelView : MonoBehaviour
{
    [SerializeField]
    private PlayerLevel _playerLevel;
    [SerializeField]
    private List<TMP_Text> _texts = new List<TMP_Text>();

    public void OnLevelChanged()
    {
        foreach(var item in _texts)
        {
            item.text = _playerLevel.Value.ToString();
        }
    }

    private void Start()
    {
        OnLevelChanged();
    }
}


