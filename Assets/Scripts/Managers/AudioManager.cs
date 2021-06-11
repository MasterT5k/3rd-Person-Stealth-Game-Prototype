using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField]
    private AudioClip _backgroundMusic = null;
    [SerializeField]
    private AudioSource _voiceOverSource = null;
    [SerializeField]
    private AudioSource _musicSource = null;

    public void BeginMusic()
    {
        if (_backgroundMusic && _musicSource != null)
        {
            _musicSource.clip = _backgroundMusic;
            _musicSource.Play();
        }
    }

    public void PlayVoiceOver(AudioClip clip)
    {
        if (clip && _voiceOverSource != null)
        {
            _voiceOverSource.clip = clip;
            _voiceOverSource.Play();
        }
    }
}
