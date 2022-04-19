using UnityEngine;
using TMPro;

public class TextTranslator : MonoBehaviour
{
    [SerializeField]
    private CurrentLanguage _language;
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private string _deutsch;
    [SerializeField]
    private string _french;
    [SerializeField]
    private string _russian;
    [SerializeField]
    private string _english;
    [SerializeField]
    private string _spanish;
    [SerializeField]
    private string _italian;

    private void OnLanguageChanged()
    {
        switch(_language.Language)
        {
            case Language.Deutsch:
            {
                _text.text = _deutsch;
                break;
            }
            case Language.French:
            {
                _text.text = _french;
                break;
            }
            case Language.Russian:
            {
                _text.text = _russian;
                break;
            }
            case Language.English:
            {
                _text.text = _english;
                break;
            }
            case Language.Spanish:
            {
                _text.text = _spanish;
                break;
            }
            case Language.Italian:
            {
                _text.text = _italian;
                break;
            }
        }

    }

    private void Start()
    {
        _language.LanguageChanged += OnLanguageChanged;
    }

    private void OnDestroy()
    {
        _language.LanguageChanged -= OnLanguageChanged;
    }
}
