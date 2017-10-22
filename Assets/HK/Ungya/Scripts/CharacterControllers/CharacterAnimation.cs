using HK.Ungya.Events.CharacterControllers;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ungya.CharacterControllers
{
    [RequireComponent(typeof(Character))]
    public sealed class CharacterAnimation : MonoBehaviour
    {
        public static class AnimatorParameter
        {
            public static readonly int Velocity = Animator.StringToHash("Velocity");
            
            public static readonly int ToAttack = Animator.StringToHash("ToAttack");
        }
        
        void Start()
        {
            var character = this.GetComponent<Character>();
            Assert.IsNotNull(character);

            var animator = this.GetComponentInChildren<Animator>();
            Assert.IsNotNull(animator);

            var mediator = this.GetComponentInChildren<AnimationEventMediator>();
            Assert.IsNotNull(mediator);
            
            mediator.Setup(character);

            character.Provider.Receive<StartAttack>()
                .SubscribeWithState(animator, (a, _animator) =>
                {
                    _animator.SetTrigger(AnimatorParameter.ToAttack);
                })
                .AddTo(this);
        }
    }
}
