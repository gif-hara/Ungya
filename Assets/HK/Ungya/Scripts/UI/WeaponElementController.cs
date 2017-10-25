using HK.Ungya.Items;
using UnityEngine;

namespace HK.Ungya.UI
{
    public sealed class WeaponElementController : MonoBehaviour
    {
        [SerializeField]
        private WeaponUIElement weaponUI;

        public void Initialize(Weapon weapon)
        {
            this.weaponUI.Apply(weapon);
        }
    }
}
