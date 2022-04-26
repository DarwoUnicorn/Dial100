using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameView : MonoBehaviour
{
    [SerializeField]
    private PlayerName _name;
    [SerializeField]
    private List<TMP_Text> _texts = new List<TMP_Text>();

    public void OnNameChanged()
    {
        foreach(var item in _texts)
        {
            item.text = _name.Name;
        }
    }

    private void Start()
    {
        OnNameChanged();
    }
}