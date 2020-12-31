using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenEffectManager : Manager
{ 
    [Serializable]
    public class FadeEffect
    {
        [SerializeField] private Image _fader; 

        /// <summary>
        /// Turn screen back to normal after screen is faded out.
        /// </summary>
        public IEnumerator FadeIn(float duration)
        { 
            _fader.CrossFadeAlpha(255, 0, true);
            _fader.gameObject.SetActive(true);

            yield return null;

            _fader.CrossFadeAlpha(1, duration, true);

            yield return new WaitForSeconds(duration);

            _fader.gameObject.SetActive(false);
        }

        /// <summary>
        /// Turn screen to complete black.
        /// </summary>
        public IEnumerator FadeOut(float duration)
        {
            _fader.gameObject.SetActive(true);
            _fader.CrossFadeAlpha(255, duration, true);
            yield return new WaitForSeconds(duration); 
        }
    }
     
    [SerializeField] private FadeEffect _fadeEffect;   

    public void FadeIn(float duration)
    {
        StartCoroutine(_fadeEffect.FadeIn(duration));
    }

    public void FadeOut(float duration)
    {
        StartCoroutine(_fadeEffect.FadeOut(duration));
    }
}
