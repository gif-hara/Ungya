using HK.Framework.EventSystems;
using HK.Ungya.CharacterControllers;
using HK.Ungya.Events.CharacterControllers;
using HK.Ungya.StateMachines;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using PlayerMove = HK.Ungya.StateMachines.PlayerMove;

namespace HK.Ungya.GameSystems
{
    public sealed class PlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        private Character character;

        void Start()
        {
            var player = Instantiate(this.character);
            var stateMachine = new StateMachine(player, new PlayerMove());
            player.Setup(stateMachine);
            
            UniRxEvent.GlobalBroker.Publish(PlayerSpawned.Get(player));
        }
    }
}
