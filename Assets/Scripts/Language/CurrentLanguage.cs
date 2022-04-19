using System;
using UnityEngine;

public class CurrentLanguage : MonoBehaviour, IPersistent
{
    public event Action LanguageChanged;

    [SerializeField]
    private Language _language = Language.None;
    [SerializeField]
    private string _id;

    public Language Language => _language;
    public string Id => _id;

    public void ChangeLanguage(ButtonLanguage language)
    {
        _language = language.Language;
        LanguageChanged?.Invoke();
        Save();
    }

    public void Save()
    {
        Saver.Save(this);
    }

    public void Load()
    {
        Saver.Load(this);
        LanguageChanged?.Invoke();
    }

    private void Start()
    {
        Load();
        if(_language == Language.None)
        {
            switch(Application.systemLanguage)
            {
                case SystemLanguage.Russian:
                {
                    _language = Language.Russian;
                    break;
                }
                case SystemLanguage.Italian:
                {
                    _language = Language.Italian;
                    break;
                }
                case SystemLanguage.French:
                {
                    _language = Language.French;
                    break;
                }
                case SystemLanguage.German:
                {
                    _language = Language.Deutsch;
                    break;
                }
                case SystemLanguage.Spanish:
                {
                    _language = Language.Spanish;
                    break;
                }
                default:
                {
                    _language = Language.English;
                    break;
                }
            }
            LanguageChanged?.Invoke();
            Saver.Save(this);
        }
    }
}
