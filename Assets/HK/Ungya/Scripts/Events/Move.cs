using HK.Framework.EventSystems;
using UnityEngine;

namespace HK.Ungya.Events.CharacterControllers
{
    public class Move : UniRxEvent<Move, Vector2, float>
    {
        private static readonly Move cache = new Move();
        public static Move GetCache(Vector2 direction, float speed)
        {
            cache.param1 = direction;
            cache.param2 = speed;
            return cache;
        }
        
        public Vector2 Direction { get { return this.param1; } }
        
        public float Speed { get { return this.param2; } }
    }
}
