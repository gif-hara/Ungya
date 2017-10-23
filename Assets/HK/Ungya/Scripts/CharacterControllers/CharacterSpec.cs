using System;
using HK.Framework.Text;
using HK.Ungya.CharacterControllers;
using UnityEngine;

namespace HK
{
    [CreateAssetMenu(menuName = "HK/Ungya/CharacterSpec")]
    public sealed class CharacterSpec : ScriptableObject
    {
        public Parameter Player;

        public Parameter[] Enemies;

        public CharacterStatus CreatePlayerStatus()
        {
            return new CharacterStatus(this.Player);
        }

        public CharacterStatus CreateEnemyStatus(int index)
        {
            return new CharacterStatus(this.Enemies[index]);
        }
        
        [Serializable]
        public struct Parameter
        {
            public StringAsset.Finder Name;
            
            public int HitPoint;

            public int Strength;

            public int Defence;

            public int NameHash { get { return this.Name.GetHashCode(); } }
        }
    }
}
