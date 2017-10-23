using HK.Framework.EventSystems;
using HK.Ungya.CharacterControllers;
using HK.Ungya.Events.CharacterControllers;
using HK.Ungya.StateMachines;
using UnityEngine;
using Move = HK.Ungya.StateMachines.Move;

namespace HK.Ungya.GameSystems
{
    public sealed class PlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        private Character character;

        void Start()
        {
            var player = Instantiate(this.character);
            var stateMachine = new StateMachine(player, new Move());
            var status = GameManager.Instance.CharacterSpec.CreatePlayerStatus();
            player.Setup(stateMachine, status);
            
            UniRxEvent.GlobalBroker.Publish(PlayerSpawned.Get(player));
        }
    }
}
