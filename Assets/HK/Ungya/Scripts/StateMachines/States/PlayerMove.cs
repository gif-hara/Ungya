using HK.Ungya.CharacterControllers;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace HK.Ungya.StateMachines
{
    public sealed class PlayerMove : State
    {
        public override void OnEnter(StateMachine stateMachine, Character character)
        {
            character.UpdateAsObservable()
                .Where(_ => character.isActiveAndEnabled)
                .SubscribeWithState(character, (_, c) =>
                {
                    c.Provider.Publish(Events.CharacterControllers.PlayerMove.GetCache(Vector2.right, 1.0f));
                })
                .AddTo(this.duringStateStream);
        }
    }
}
