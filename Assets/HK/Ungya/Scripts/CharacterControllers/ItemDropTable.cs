using System;
using System.Collections.Generic;
using HK.Framework.Text;
using HK.Ungya.Items;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HK.Ungya.CharacterControllers
{
    [CreateAssetMenu(menuName = "HK/Ungya/ItemDropTable")]
    public sealed class ItemDropTable : ScriptableObject
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

            /// <summary>
            /// アイテム取得の抽選を行う
            /// </summary>
            public List<Item> Lottery(ItemSpec spec)
            {
                var result = new List<Item>();
                foreach (var element in this.Elements)
                {
                    if (!element.Possible)
                    {
                        continue;
                    }
                    
                    result.Add(spec.Get(element.ItemName.GetHashCode()));
                }

                return result;
            }
        }
        
        [Serializable]
        public class Element
        {
            [Range(0.0f, 1.0f)]
            public float Rate;
            
            public StringAsset.Finder ItemName;

            /// <summary>
            /// <see cref="Rate"/>からアイテムを取得したか返す
            /// </summary>
            public bool Possible
            {
                get { return this.Rate >= Random.value; }
            }
        }
    }
}
