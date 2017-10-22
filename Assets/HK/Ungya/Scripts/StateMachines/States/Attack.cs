using System.Diagnostics;
using HK.Ungya.CharacterControllers;
using HK.Ungya.Events.CharacterControllers;
using UniRx;
using UnityEngine.Assertions;
using Debug = UnityEngine.Debug;

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
            character.SetTarget(this.target);
            character.Provider.Publish(Events.CharacterControllers.StartAttack.Get(this.target));
            
            character.Provider.Receive<Attacked>()
                .SubscribeWithState2(this, character, (_, _this, c) =>
                {
                    if (_this.target.IsDead)
                    {
                        c.StateMachine.Change(new PlayerMove());
                    }
                    else
                    {
                        c.Provider.Publish(Events.CharacterControllers.StartAttack.Get(_this.target));
                    }
                })
                .AddTo(this.duringStateStream);
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        private void StartAttack(Character character)
        {
//            Observable.Timer(TimeSpan.FromSeconds(1.0f))
//                .SubscribeWithState2(character, this, (_, c, _this) =>
//                {
//                    c.Attack(_this.target);
//                    if (_this.target.IsDead)
//                    {
//                        c.StateMachine.Change(new PlayerMove());
//                    }
//                    else
//                    {
//                        _this.StartAttack(character);
//                    }
//                })
//                .AddTo(this.duringStateStream);
        }
    }
}
