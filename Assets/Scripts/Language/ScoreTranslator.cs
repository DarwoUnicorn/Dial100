using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTranslator : TextTranslator
{
    private int _score;

    public void OnScoreChanged(int score)
    {
        _score = score;
        OnLanguageChanged();
    }

    protected override void SetText(string text)
    {
        base.SetText(text + " " + _score.ToString());
        base.SetText($"{ text } { _score.ToString() }");
    }
}
