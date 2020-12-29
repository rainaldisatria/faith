using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatusManager : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _manaBar;
    [SerializeField] private FloatEventChannelSO _onPlayerHitted; 

    private void OnEnable()
    {
        _onPlayerHitted.OnEventRaised += SetHealth; 
    }

    private void OnDisable()
    {
        _onPlayerHitted.OnEventRaised -= SetHealth; 
    }

    public void SetHealth(float hpFillTarget)
    { 
        StopCoroutine("ApplyHealth");
        StartCoroutine("ApplyHealth", hpFillTarget);
    }

    public void SetMana(float manaFillTraget)
    { 
        StopCoroutine("ApplyMana");
        StartCoroutine("ApplyMana", manaFillTraget);
    }

    private IEnumerator ApplyHealth(float hpFillTarget)
    {
        while(Mathf.Abs(_healthBar.fillAmount - hpFillTarget) > 0.01f)
        {
            yield return null;
            _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, hpFillTarget, 5 * Time.deltaTime);
        }
    }

    private IEnumerator ApplyMana(float manaFillTarget)
    {
        while (Mathf.Abs(_healthBar.fillAmount - manaFillTarget) > 0.01f)
        {
            yield return null;
            _manaBar.fillAmount = Mathf.Lerp(_manaBar.fillAmount, manaFillTarget, 5 * Time.deltaTime);
        }
    }
}
