using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Strike Skill")]
public class StrikeSkill : DamageSkill
{ 
    [SerializeField] private float speed = 0.5f;

    public override IEnumerator Execute(Battler battler, Transform target)
    { 
        battler.transform.LookAt(target);
        battler.transform.eulerAngles = new Vector3(0, battler.transform.eulerAngles.y, 0);

        yield return base.Execute(battler, target);

        if (target == null)
        {
            GameObject dummy= new GameObject();
            dummy.transform.position = battler.transform.position + battler.transform.forward * 15;

            target = dummy.transform;
        } 
        
        Strike(target, battler);
        battler.StartCoroutine(Done(battler));
    }

    protected override IEnumerator Done(Battler battler)
    {
        yield return base.Done(battler); 
        battler.GetComponentInChildren<DamageDealerTrigger>().Disable();
    }

    public void Strike(Transform target, Battler user)
    { 
        if (target == null)
            return;
         
        GameObject sword = GameObject.FindGameObjectWithTag("PlayerSword");
        Vector3 swordDefaultPos = sword.transform.localPosition;
        Vector3 swordDefaultRot = sword.transform.localEulerAngles;
        Transform swordHand = sword.transform.parent; 

        sword.transform.parent = null;
        sword.transform.DOMove(target.position + new Vector3(0, 1, 0), speed / 2);
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

        user.transform.DOMove(target.root.position, speed).SetEase(Ease.InExpo)
            .OnComplete(() => StrikeEnded(user, swordDefaultPos, swordDefaultRot, swordHand));

        
        Animator[] animators = user.GetComponentsInChildren<Animator>();
        animators.PlayAll((int id) =>
        {
            animators[id].speed = 0;
        });

        ShowBody(false, user);
    } 

    public void StrikeEnded(Battler user, Vector3 swordDefaultPos, Vector3 swordDefaultRot, Transform swordHand)
    { 
        Animator[] animators = user.GetComponentsInChildren<Animator>();
        animators.PlayAll((int id) =>
        {
            animators[id].speed = 1;
        });
        ShowBody(true, user);

        Protagonist protagonist = user as Protagonist; 
        protagonist.GetComponentInChildren<DamageDealerTrigger>().Enable(Damage);

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
