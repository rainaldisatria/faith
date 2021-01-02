using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Experiment : MonoBehaviour
{
    public Transform targetTrans;
    public float duration = 1;
    public Animator[] animators;

    public Transform sword;
    public  Transform swordHand;

    private Vector3 swordDefaultPos;
    private Vector3 swordDefaultRot;

    private void Start()
    {
        swordDefaultPos = sword.transform.localPosition;
        swordDefaultRot = sword.transform.localEulerAngles;
    }

    public void Warp()
    { 
        GameObject clone = Instantiate(gameObject, transform.position, transform.rotation);
        Destroy(clone.GetComponent<Protagonist>());
        Destroy(clone.GetComponent<StateMachine>());

        Animator[] cloneAnimators = clone.GetComponentsInChildren<Animator>();
        foreach(Animator cloneAnimator in cloneAnimators)
        {
            Destroy(cloneAnimator);
        }

        Destroy(clone.GetComponent<Collider>());

        // Actually moving the object 
        transform.DOMove(targetTrans.position, duration, false).SetEase(Ease.InExpo).OnComplete(() => FinishWrap());

        // Freeze animation
        animators = GetComponentsInChildren<Animator>();
        animators.PlayAll((int id) =>
        {
            animators[id].speed = 0;
        });

        ShowBody(false);

        // Setup the sword
        swordDefaultPos = sword.transform.localPosition;
        sword.parent = null;
        sword.DOMove(targetTrans.position, duration / 2);
        sword.DORotate(new Vector3(0, 90, 0), .3f);
    }

    public void FinishWrap()
    {
        animators.PlayAll((int id) =>
        {
            animators[id].speed = 1;
        });
        ShowBody(true);

        sword.parent = swordHand;
        sword.localPosition = swordDefaultPos;
        sword.localEulerAngles = swordDefaultRot;
    }

    private void ShowBody(bool state)
    {
        SkinnedMeshRenderer[] skinMeshes = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach(SkinnedMeshRenderer skin in skinMeshes)
        {
            skin.enabled = state;
        }
    }
}
