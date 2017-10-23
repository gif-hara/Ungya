using System;
using System.Collections.Generic;
using HK.Framework.Text;
using UnityEngine;

namespace HK.Ungya.Items
{
    [CreateAssetMenu(menuName = "HK/Ungya/ItemSpec")]
    public sealed class ItemSpec : ScriptableObject
    {
        public List<Parameter> Items = new List<Parameter>();
        
        [Serializable]
        public class Parameter
        {
            public StringAsset.Finder Name;

            public StringAsset.Finder Description;

            public ItemType Type;

            public int SpecId;

            public int NameHash { get { return this.Name.GetHashCode(); } }
        }
    }
}
