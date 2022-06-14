using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundButton : IButton, IPersistent
{
    [SerializeField]
    private AudioMixer _mixer;
    [SerializeField]
    private AudioMixerSnapshot _offMixer;
    [SerializeField]
    private AudioMixerSnapshot _onMixer;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Sprite _soundOn;
    [SerializeField]
    private Sprite _soundOff;
    [SerializeField]
    private bool _isActive = true;
    [SerializeField]
    private string _id;

    public string Id => _id;

    public override void Action()
    {
        _isActive = !_isActive;
        Save();
        CheckIsActive();
    }

    public void Load()
    {
        SoundButton temp = gameObject.AddComponent<SoundButton>();
        Saver.Load(temp, Id);
        _isActive = temp._isActive;
        CheckIsActive();
        Destroy(temp);
    }

    public void Save()
    {
        Saver.Save(this);
    }

    private void CheckIsActive()
    {
        if(_isActive)
        {
            _image.sprite = _soundOn;
            _onMixer.TransitionTo(0);
            return;
        }
        _image.sprite = _soundOff;
        _offMixer.TransitionTo(0);
    }

    private void Start()
    {
        Load();
    }
}
