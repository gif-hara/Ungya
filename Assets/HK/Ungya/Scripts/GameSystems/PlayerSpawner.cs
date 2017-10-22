using HK.Ungya.CharacterControllers;
using HK.Ungya.StateMachines;
using UnityEngine;

namespace HK.Ungya.GameSystems
{
    public sealed class PlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        private Character character;

        void Start()
        {
            var instance = Instantiate(this.character);
            var stateMachine = new StateMachine(instance, new PlayerMove());
            instance.Setup(stateMachine);
        }
    }
}
