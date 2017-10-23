using System;
using HK.Framework.Text;

namespace HK.Ungya.Items
{
    [Serializable]
    public sealed class Item
    {
        public StringAsset.Finder Name;

        public StringAsset.Finder Description;

        public ItemType Type;

        public int SpecId;

        public int NameHash { get { return this.Name.GetHashCode(); } }
    }
}
