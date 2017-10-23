using System;
using System.Collections.Generic;
using HK.Framework.Text;
using UnityEngine;

namespace HK.Ungya.CharacterControllers
{
    [CreateAssetMenu(menuName = "HK/Ungya/DropItemTable")]
    public sealed class DropItemTable : ScriptableObject
    {
        [SerializeField]
        private List<Table> Tables = new List<Table>();

        private Dictionary<int, Table> cachedTables = new Dictionary<int, Table>();

        public Table Get(int characterNameHash)
        {
            Table result;
            if (!this.cachedTables.TryGetValue(characterNameHash, out result))
            {
                result = this.Tables.Find(t => t.CharacterName.GetHashCode() == characterNameHash);
                this.cachedTables.Add(characterNameHash, result);
            }

            return result;
        }
        
        [Serializable]
        public class Table
        {
            /// <summary>
            /// このテーブルを利用するキャラクター
            /// </summary>
            public StringAsset.Finder CharacterName;
            
            public List<Element> Elements;
        }
        
        [Serializable]
        public class Element
        {
            [Range(0.0f, 1.0f)]
            public float Rate;
            
            public StringAsset.Finder ItemName;
        }
    }
}
