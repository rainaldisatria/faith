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

            yield return null;

            _fader.CrossFadeAlpha(1, duration, true);
        }

        /// <summary>
        /// Turn screen to complete black.
        /// </summary>
        public IEnumerator FadeOut(float duration)
        {
            _fader.CrossFadeAlpha(255, duration, true);
            yield return null;
        }
    }
     
    [SerializeField] private FadeEffect _fadeEffect;   

    public void FadeIn(float duration = 0.5f)
    {
        StartCoroutine(_fadeEffect.FadeIn(duration));
    }

    public void FadeOut(float duration = 0.5f)
    {
        StartCoroutine(_fadeEffect.FadeOut(duration));
    }
}
