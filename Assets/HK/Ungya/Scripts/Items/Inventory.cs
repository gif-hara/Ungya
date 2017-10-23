using System.Collections.Generic;

namespace HK.Ungya.Items
{
    public sealed class Inventory
    {
        public readonly List<InstanceItem> Items = new List<InstanceItem>();

        public void Add(InstanceItem item)
        {
            this.Items.Add(item);
        }

        public void Add(List<Item> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public void Add(Item item)
        {
            this.Add(InstanceItemFactory.Create(item));
        }
    }
}
