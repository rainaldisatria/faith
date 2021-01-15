using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip _clipToPlay;
    [SerializeField] private ManagerSO _audioManager;
    [SerializeField] private bool playOnStart = true;

    private void Start()
    {
        if (playOnStart)
        {
            StartCoroutine(((AudioManager)(_audioManager.Manager)).FadeOutMusic(_clipToPlay, 0.25f));
        }
    }
}
