using HK.Framework.EventSystems;
using HK.Ungya.CharacterControllers;
using HK.Ungya.Events.UI;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ungya.StateMachines
{
    public sealed class Move : State
    {
        private float speed = 1.0f;
        
        public override void OnEnter(StateMachine stateMachine, Character character)
        {

            UniRxEvent.GlobalBroker.Receive<ChangeUI>()
                .SubscribeWithState(this, (c, _this) =>
                {
                    _this.speed = c.UIType == UIType.Main ? 1.0f : 0.0f;
                })
                .AddTo(this.duringStateStream);
            
            character.UpdateAsObservable()
                .Where(_ => character.isActiveAndEnabled)
                .SubscribeWithState2(this, character, (_, _this, c) =>
                {
                    c.Provider.Publish(Events.CharacterControllers.Move.GetCache(Vector2.right, _this.speed));
                })
                .AddTo(this.duringStateStream);
            
            character.OnTriggerEnter2DAsObservable()
                .SubscribeWithState(character, (c, _player) =>
                {
                    var target = c.gameObject.GetComponent<Character>();
                    Assert.IsNotNull(target);
                    character.StateMachine.Change(new Attack(target));
                })
                .AddTo(this.duringStateStream);
        }
    }
}
