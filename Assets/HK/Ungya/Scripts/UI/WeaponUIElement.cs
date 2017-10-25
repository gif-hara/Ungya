using System;
using HK.Ungya.GameSystems;
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
            var format = UserInterfaceText.Instance;
            this.WeaponName.text = weapon.Base.Name.Get;
            this.Strength.text = format.Strength.Format(weapon.Strength.ToString());
            this.Defence.text = format.Defence.Format(weapon.Defence.ToString());
            this.MoveSpeed.text = format.MoveSpeed.Format(weapon.MoveSpeed.ToString());
            this.AttackSpeed.text = format.AttackSpeed.Format(weapon.AttackSpeed.ToString());
            this.Luck.text = format.Luck.Format(weapon.Luck.ToString());
        }
    }
}
