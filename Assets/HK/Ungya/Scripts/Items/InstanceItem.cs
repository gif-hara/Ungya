using System;

namespace HK.Ungya.Items
{
    /// <summary>
    /// 実際に扱えるアイテム
    /// </summary>
    [Serializable]
    public abstract class InstanceItem
    {
        public readonly Item Base;

        public InstanceItem(Item item)
        {
            this.Base = item;
        }
    }
}
