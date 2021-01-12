using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image _healthImage;
    [SerializeField] private float duration = 5;
    [SerializeField] private Vector3 offset;

    public event UnityAction<Healthbar> OnHealthbarFinishedDisplaying;
    public int InstanceID { get; private set; }

    private float startTime;

    public void SetHealthbar(int instanceID, Transform trans, BattlerData data)
    {
        InstanceID = instanceID;
        StartCoroutine(SetHealthbarRoutine(trans, data));
    } 

    private IEnumerator SetHealthbarRoutine(Transform trans, BattlerData data)
    {
        startTime = Time.time;
        this.gameObject.SetActive(true);

        while(startTime + duration > Time.time && trans != null)
        {
            if (data == null | data.HP <= 0)
                    OnHealthbarFinishedDisplaying.Invoke(this);

            this.transform.position = Camera.main.WorldToScreenPoint(trans.position + offset);

            this._healthImage.fillAmount = Mathf.Lerp(this._healthImage.fillAmount, ((float)data.HP) / data.MaxHP, 5);

            yield return null;
        }

        OnHealthbarFinishedDisplaying.Invoke(this);
    } 

    public void ResetTimer()
    {
        startTime = Time.time;
    }
}
