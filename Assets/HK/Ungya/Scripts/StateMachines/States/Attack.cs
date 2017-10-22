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
            StartAttack(character);
        }

        private void StartAttack(Character character)
        {
            Observable.Timer(TimeSpan.FromSeconds(1.0f))
                .SubscribeWithState2(character, this, (_, c, _this) =>
                {
                    c.Attack(_this.target);
                    if (_this.target.IsDead)
                    {
                        c.StateMachine.Change(new PlayerMove());
                    }
                    else
                    {
                        _this.StartAttack(character);
                    }
                })
                .AddTo(this.duringStateStream);
        }
    }
}
