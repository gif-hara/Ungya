using HK.Framework.EventSystems;
using UnityEngine;

namespace HK.Ungya.Events.CharacterControllers
{
    public class PlayerMove : UniRxEvent<PlayerMove, Vector2, float>
    {
        private static readonly PlayerMove cache = new PlayerMove();
        public static PlayerMove GetCache(Vector2 direction, float speed)
        {
            cache.param1 = direction;
            cache.param2 = speed;
            return cache;
        }
        
        public Vector2 Direction { get { return this.param1; } }
        
        public float Speed { get { return this.param2; } }
    }
}
