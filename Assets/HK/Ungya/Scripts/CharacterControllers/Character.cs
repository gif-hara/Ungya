using HK.Ungya.StateMachines;
using UniRx;
using UnityEngine;

namespace HK.Ungya.CharacterControllers
{
    public class Character : MonoBehaviour
    {
        public IMessageBroker Provider { private set; get; }
        
        public StateMachine StateMachine { private set; get; }

        void Awake()
        {
            this.Provider = new MessageBroker();
        }

        public void Setup(StateMachine stateMachine)
        {
            this.StateMachine = stateMachine;
        }
    }
}
