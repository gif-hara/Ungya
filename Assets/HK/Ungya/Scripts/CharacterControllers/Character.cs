using HK.Ungya.Events.CharacterControllers;
using HK.Ungya.StateMachines;
using UniRx;
using UnityEngine;

namespace HK.Ungya.CharacterControllers
{
    public class Character : MonoBehaviour
    {
        public IMessageBroker Provider { private set; get; }
        
        public StateMachine StateMachine { private set; get; }

        public Transform CachedTransform { private set; get; }

        public CharacterStatus Status { private set; get; }
        
        public bool IsDead { get { return this.Status.IsDead; } }

        private Character target;

        void Awake()
        {
            this.Provider = new MessageBroker();
            this.CachedTransform = this.transform;
        }

        public void Setup(StateMachine stateMachine, CharacterStatus status)
        {
            this.StateMachine = stateMachine;
            this.Status = status;
        }

        public void SetTarget(Character target)
        {
            this.target = target;
        }

        public void Attack()
        {
            this.target.TakeDamage(this.Status.Instance.Strength);
        }

        public void TakeDamage(int damage)
        {
            // TODO: プレイヤーのダメージ処理
            if (this.tag == "Player")
            {
                return;
            }
            
            this.Status.TakeDamage(damage);
            if (this.Status.IsDead)
            {
                Destroy(this.gameObject);
                this.Provider.Publish(Death.Get());
            }
        }
    }
}
