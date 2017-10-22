using HK.Framework.EventSystems;
using HK.Ungya.Events.CharacterControllers;
using HK.Ungya.GameSystems;
using HK.Ungya.StateMachines;
using UniRx;
using UnityEngine;
using PlayerMove = HK.Ungya.Events.CharacterControllers.PlayerMove;

namespace HK.Ungya.CharacterControllers
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private Character character;

        [SerializeField]
        private float distance;
        
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

        private void ReceivePlayerMove(Character player)
        {
            player.Provider.Receive<PlayerMove>()
                .SubscribeWithState2(this, player, (p, _this, _player) =>
                {
                    _this.spawnDistance -= p.Speed * Time.deltaTime;
                    if (_this.spawnDistance <= 0.0f)
                    {
                        _this.SpawnEnemy(_player, _this.character, p.Direction);
                        _this.SetupSpawnDistance(1.0f);
                    }
                })
                .AddTo(this);
        }

        private void SpawnEnemy(Character player, Character character, Vector2 direction)
        {
            var enemy = Instantiate(character);
            var stateMachine = new StateMachine(enemy, new Idle());
            var status = GameManager.Instance.CharacterSpec.CreateEnemyStatus(0);
            enemy.Setup(stateMachine, status);
            enemy.CachedTransform.position = new Vector3(direction.x * this.distance , 0.0f, 0.0f);
            player.Provider.Receive<PlayerMove>()
                .SubscribeWithState(enemy, (p, _enemy) =>
                {
                    var speed = p.Speed * Time.deltaTime;
                    var velocity = new Vector3(p.Direction.x * -speed, p.Direction.y * speed, 0.0f);
                    _enemy.CachedTransform.position += velocity;
                })
                .AddTo(enemy);
        }

        private void SetupSpawnDistance(float value)
        {
            this.spawnDistance = value;
        }
    }
}
