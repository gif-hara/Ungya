using System.Collections.Generic;
using UnityEngine;

namespace HK.Ungya.Items
{
    [CreateAssetMenu(menuName = "HK/Ungya/ItemSpec")]
    public sealed class ItemSpec : ScriptableObject
    {
        public List<Item> Items = new List<Item>();
        
        private Dictionary<int, Item> cachedItems = new Dictionary<int, Item>();

        public Item Get(int itemNameHash)
        {
            Item result;
            if (!this.cachedItems.TryGetValue(itemNameHash, out result))
            {
                result = this.Items.Find(i => i.NameHash == itemNameHash);
                this.cachedItems.Add(itemNameHash, result);
            }

            return result;
        }
    }
}
