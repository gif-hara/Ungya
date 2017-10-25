using System;
using HK.Ungya.Items;
using UnityEngine;
using UnityEngine.UI;

namespace HK.Ungya.UI
{
    [Serializable]
    public sealed class WeaponUIElement
    {
        public Text WeaponName;

        public Text Strength;

        public Text Defence;

        public Text MoveSpeed;

        public Text AttackSpeed;
        
        public Text Luck;

        public RectTransform AbilityParent;

        public void Apply(Weapon weapon)
        {
            Debug.Log("TODO");
        }
    }
}
