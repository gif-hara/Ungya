using HK.Framework.EventSystems;
using UnityEngine;

namespace HK.Ungya.Events.CharacterControllers
{
    public class PlayerMove : UniRxEvent<PlayerMove, Vector2>
    {
        private static readonly PlayerMove cache = new PlayerMove();
        public static PlayerMove GetCache(Vector2 velocity)
        {
            cache.param1 = velocity;
            return cache;
        }
        
        public Vector2 Velocity { get { return this.param1; } }
    }
}
