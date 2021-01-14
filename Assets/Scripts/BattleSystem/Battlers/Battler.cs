using System.Collections;
using UnityEngine;

namespace AnthaGames.Assets.Scripts.BattleSystem.Battlers
{
    public abstract class Battler : MonoBehaviour, IDamageable, IDamageDealer
    {
        #region Fields
        [SerializeField] protected BattlerData Data;

        protected Animator[] Animators;
        protected Transform Target;

        protected Transform Head;
        protected Transform Mid;
        private DamageTriggerController _damageDealer;
        #endregion

        #region State machine fields
        [HideInInspector] public bool IsAttacking;
        [HideInInspector] public bool IsHitted;
        [HideInInspector] public bool IsDead;
        [HideInInspector] public bool IsUsingSkill;
        #endregion

        #region Behaviour  
        // Initialization
        protected virtual void Awake()
        {
            Animators = GetComponentsInChildren<Animator>();

            Head = transform.Find("Head");
            if (Head == null)
                Debug.LogError("Battler has no head referenced");

            Mid = transform.Find("Mid");
            if (Mid == null)
                Debug.LogError("Battler has no mid referenced");

            _damageDealer = new DamageTriggerController(GetComponentsInChildren<DamageDealerTrigger>());

            Data = Instantiate(Data);
        }

        public abstract void Attack();

        public abstract void UseSkill();

        protected virtual void CheckCondition()
        {
            if (Data.HP <= 0)
            {
                Dead();
            }
        }

        protected virtual void Dead()
        {
            IsDead = true;
            StopAllCoroutines();
        }

        private IEnumerator SetIsHittedToTrue()
        {
            IsHitted = true;
            yield return null;
            IsHitted = false;
        }
        #endregion

        #region IDamageable
        public virtual void TakeDamage(int damage, Transform damager)
        {
            StartCoroutine(SetIsHittedToTrue());

            DealDamageEnded();

            Data.HP -= damage;

            CheckCondition();
        }
        #endregion

        #region IDamageDealer
        public void DealDamageStart()
        {
            _damageDealer.Start(Data.Damage);
        }

        public void DealDamageEnded()
        {
            _damageDealer.End();
        }
        #endregion
    }

}

