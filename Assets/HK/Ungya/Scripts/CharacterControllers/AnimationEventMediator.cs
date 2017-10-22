using HK.Ungya.Events.CharacterControllers;
using UnityEngine;

namespace HK.Ungya.CharacterControllers
{
    public sealed class AnimationEventMediator : MonoBehaviour
    {
        private Character character;
        
        public void Setup(Character character)
        {
            this.character = character;
        }

        public void Attack()
        {
            this.character.Attack();
        }

        public void EndAttack()
        {
            this.character.Provider.Publish(Attacked.Get());
        }
    }
}
