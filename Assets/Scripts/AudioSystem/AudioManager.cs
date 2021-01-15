using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Manager
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private VoidEventChannelSO _onSceneLoading;

    private void OnEnable()
    {
        _onSceneLoading.OnEventRaised += FadeInMusicVoid;
    }

    private void OnDisable()
    {
        _onSceneLoading.OnEventRaised -= FadeInMusicVoid;
    }

    public void FadeInMusicVoid()
    {
        StartCoroutine(FadeInMusic(0.25f));
    }

    public IEnumerator FadeInMusic(float fadeTime)
    {
        float startVolume = _audioSource.volume;

        while (_audioSource.volume > 0)
        {
            _audioSource.volume -= startVolume * Time.deltaTime / fadeTime; 
            yield return null;
        }

        _audioSource.Stop();
        _audioSource.volume = startVolume;
    }

    public IEnumerator FadeOutMusic(AudioClip clip, float fadeTime = 0.1f)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
        float startVolume = _audioSource.volume;
        _audioSource.volume = 0;

        while (_audioSource.volume < startVolume)
        {
            _audioSource.volume += startVolume * Time.deltaTime / fadeTime;
            yield return null;
        } 
    }
}
