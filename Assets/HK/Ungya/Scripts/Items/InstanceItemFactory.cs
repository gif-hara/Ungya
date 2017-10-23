using UnityEngine.Assertions;

namespace HK.Ungya.Items
{
    public static class InstanceItemFactory
    {
        public static InstanceItem Create(Item item)
        {
            switch (item.Type)
            {
                case ItemType.AbilityMaterial:
                    return new Material(item);
                case ItemType.Weapon:
                    return new Weapon(item);
            }

            Assert.IsTrue(false, string.Format("未対応の値です {0}", item.Type));
            return null;
        }
    }
}
