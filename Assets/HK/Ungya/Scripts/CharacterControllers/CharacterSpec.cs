using System;
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
        public class Parameter
        {
            public string name;
            
            public int hitPoint;

            public int strength;

            public int defence;
        }
    }
}
