using HK.Framework.EventSystems;
using HK.Ungya.Events.CharacterControllers;
using UniRx;
using UnityEngine;

namespace HK.Ungya.CharacterControllers
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        private float spawnDistance = 0.0f;
        
        void Awake()
        {
            UniRxEvent.GlobalBroker.Receive<PlayerSpawned>()
                .SubscribeWithState(this, (p, _this) =>
                {
                    _this.ReceivePlayerMove(p.Player);
                })
                .AddTo(this);
        }

        private void ReceivePlayerMove(Character character)
        {
            character.Provider.Receive<PlayerMove>()
                .SubscribeWithState(this, (p, _this) =>
                {
                    _this.spawnDistance -= p.Speed * Time.deltaTime;
                    if (_this.spawnDistance <= 0.0f)
                    {
                        Debug.Log("Spawn!");
                        _this.SetupSpawnDistance(1.0f);
                    }
                })
                .AddTo(this);
        }

        private void SetupSpawnDistance(float value)
        {
            this.spawnDistance = value;
        }
    }
}
