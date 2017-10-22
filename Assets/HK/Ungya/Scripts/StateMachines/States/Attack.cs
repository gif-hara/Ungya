using System;
using HK.Ungya.CharacterControllers;
using UniRx;
using UnityEngine.Assertions;

namespace HK.Ungya.StateMachines
{
    public sealed class Attack : State
    {
        private Character target;
        
        public Attack(Character target)
        {
            this.target = target;
            Assert.IsNotNull(this.target);
        }
        
        public override void OnEnter(StateMachine stateMachine, Character character)
        {
            Observable.Timer(TimeSpan.FromSeconds(1.0f))
                .SubscribeWithState2(character, target, (_, c, t) =>
                {
                    c.Attack(t);
                })
                .AddTo(this.duringStateStream);
        }
    }
}
