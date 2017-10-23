using HK.Framework.EventSystems;
using UnityEngine;

namespace HK.Ungya.Events.CharacterControllers
{
    public class Move : UniRxEvent<Move, Vector2, float>
    {
        public Vector2 Direction { get { return this.param1; } }
        
        public float Speed { get { return this.param2; } }
    }
}
