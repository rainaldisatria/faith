using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Strike Skill")]
public class StrikeSkill : SkillBaseSO
{
    [SerializeField] private ManagerSO _targetManager;
    [SerializeField] private float speed = 0.5f;

    public override IEnumerator Execute(Battler battler)
    {
        battler.IsUsingSkill = true;
        battler.GetComponent<Animator>().CrossFade(Animator.StringToHash(AnimationToPlay), TransitionDuration);

        Transform target = ((TargetManager)(_targetManager.Manager)).Target; 

        battler.transform.LookAt(target); 
        battler.transform.eulerAngles = new Vector3(0, battler.transform.eulerAngles.y, 0);
         
        yield return new WaitForSeconds(Delay);
        
        Warp(target, battler);
        battler.StartCoroutine(Done(battler));
    }

    public void Warp(Transform target, Battler user)
    { 
        if (target == null)
            return;
         
        GameObject sword = GameObject.FindGameObjectWithTag("PlayerSword");
        Vector3 swordDefaultPos = sword.transform.localPosition;
        Vector3 swordDefaultRot = sword.transform.localEulerAngles;
        Transform swordHand = sword.transform.parent; 

        sword.transform.parent = null;
        sword.transform.DOMove(target.position, speed / 2);
        sword.transform.DOLookAt(target.position, .2f, AxisConstraint.None);
        sword.GetComponentInChildren<TrailRenderer>().emitting = true;

        GameObject clone = Instantiate(user.gameObject, user.transform.position, user.transform.rotation);
        Destroy(clone, speed);
        Destroy(clone.GetComponent<Protagonist>());
        Destroy(clone.GetComponent<StateMachine>());
        Destroy(clone.GetComponent<Collider>());

        Animator[] cloneAnimators = clone.GetComponentsInChildren<Animator>();
        foreach (Animator cloneAnimator in cloneAnimators)
        {
            Destroy(cloneAnimator);
        }

        user.transform.DOMove(target.position, speed, false).SetEase(Ease.InExpo)
            .OnComplete(() => FinishWrap(user, swordDefaultPos, swordDefaultRot, swordHand));

        
        Animator[] animators = user.GetComponentsInChildren<Animator>();
        animators.PlayAll((int id) =>
        {
            animators[id].speed = 0;
        });

        ShowBody(false, user);
    } 

    public void FinishWrap(Battler user, Vector3 swordDefaultPos, Vector3 swordDefaultRot, Transform swordHand)
    {
        Animator[] animators = user.GetComponentsInChildren<Animator>();
        animators.PlayAll((int id) =>
        {
            animators[id].speed = 1;
        });
        ShowBody(true, user);

        GameObject sword = GameObject.FindGameObjectWithTag("PlayerSword");

        sword.transform.parent = swordHand;
        sword.transform.localPosition = swordDefaultPos;
        sword.transform.localEulerAngles = swordDefaultRot;
        sword.GetComponentInChildren<TrailRenderer>().emitting = false;
    }

    private void ShowBody(bool state, Battler user)
    {
        SkinnedMeshRenderer[] skinMeshes = user.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer skin in skinMeshes)
        {
            skin.enabled = state;
        }
    }
}
