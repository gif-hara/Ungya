using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ungya.Items
{
    public sealed class Inventory
    {
        /// <summary>
        /// 素材
        /// </summary>
        /// <remarks>
        /// key = ItemNameHash
        /// value = 個数
        /// </remarks>
        public readonly Dictionary<int, int> Materials = new Dictionary<int, int>();

        /// <summary>
        /// 武器
        /// </summary>
        public readonly List<Weapon> Weapons = new List<Weapon>();

        public void Add(List<Item> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public void Add(Item item)
        {
            switch (item.Type)
            {
                case ItemType.Material:
                    this.AddMaterial(item);
                    break;
                case ItemType.Weapon:
                    this.AddWeapon(item);
                    break;
                default:
                    Assert.IsTrue(false, string.Format("未対応の値です {0}", item.Type));
                    break;
            }
        }

        private void AddMaterial(Item item)
        {
            Assert.AreEqual(item.Type, ItemType.Material);
            var itemNameHash = item.NameHash;
            if (this.Materials.ContainsKey(itemNameHash))
            {
                ++this.Materials[itemNameHash];
            }
            else
            {
                this.Materials.Add(itemNameHash, 1);
            }
        }

        private void AddWeapon(Item item)
        {
            Assert.AreEqual(item.Type, ItemType.Weapon);
            this.Weapons.Add(new Weapon(item));
        }
    }
}
