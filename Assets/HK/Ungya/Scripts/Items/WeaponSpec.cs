using System;
using System.Collections.Generic;
using UnityEngine;

namespace HK.Ungya.Items
{
    [CreateAssetMenu(menuName = "HK/Ungya/WeaponSpec")]
    public sealed class WeaponSpec : ScriptableObject
    {
        public List<Parameter> Parameters = new List<Parameter>();
        
        [Serializable]
        public class Parameter
        {
            public Primitive.RangeInt Strength;

            public Primitive.RangeInt Defence;

            public Primitive.RangeInt MoveSpeed;

            public Primitive.RangeInt AttackSpeed;

            public Primitive.RangeInt Luck;
        }
    }
}
