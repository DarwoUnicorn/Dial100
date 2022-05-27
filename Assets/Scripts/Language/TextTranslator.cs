using UnityEngine;
using TMPro;

public class TextTranslator : MonoBehaviour
{
    [SerializeField]
    protected GameLanguage _language;
    [SerializeField]
    protected TMP_Text _text;
    [SerializeField] [TextArea]
    protected string _deutsch;
    [SerializeField] [TextArea]
    protected string _french;
    [SerializeField] [TextArea]
    protected string _russian;
    [SerializeField] [TextArea]
    protected string _english;
    [SerializeField] [TextArea]
    protected string _spanish;
    [SerializeField] [TextArea]
    protected string _italian;

    protected void OnLanguageChanged()
    {
        switch(_language.Language)
        {
            case Language.Deutsch:
            {
                SetText(_deutsch);
                break;
            }
            case Language.French:
            {
                SetText(_french);
                break;
            }
            case Language.Russian:
            {
                SetText(_russian);
                break;
            }
            case Language.English:
            {
                SetText(_english);
                break;
            }
            case Language.Spanish:
            {
                SetText(_spanish);
                break;
            }
            case Language.Italian:
            {
                SetText(_italian);
                break;
            }
        }

    }

    protected virtual void SetText(string text)
    {
        _text.text = text;
    }

    #region MonoBehaviour

    private void Start()
    {
        _language.LanguageChanged += OnLanguageChanged;
    }

    private void OnEnable()
    {
        OnLanguageChanged();
    }

    private void OnDestroy()
    {
        _language.LanguageChanged -= OnLanguageChanged;
    }

    #endregion
}
