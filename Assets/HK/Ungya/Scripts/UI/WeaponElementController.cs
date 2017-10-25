using HK.Ungya.Items;
using UnityEngine;
using UnityEngine.UI;

namespace HK.Ungya.UI
{
    [RequireComponent(typeof(Button))]
    public sealed class WeaponElementController : MonoBehaviour
    {
        [SerializeField]
        private WeaponUIElement weaponUI;
        
        public Button Button { private set; get; }

        void Awake()
        {
            this.Button = this.GetComponent<Button>();
        }

        public void Initialize(Weapon weapon)
        {
            this.weaponUI.Apply(weapon);
        }
    }
}
