using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLevelView : MonoBehaviour
{
    [SerializeField]
    private PlayerData _data;
    [SerializeField]
    private List<TMP_Text> _texts = new List<TMP_Text>();

    public void OnLevelChanged()
    {
        foreach(var item in _texts)
        {
            item.text = _data.Level.Value.ToString();
        }
    }

    private void Start()
    {
        OnLevelChanged();
    }
}


