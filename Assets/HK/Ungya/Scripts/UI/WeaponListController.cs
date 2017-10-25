using System.Collections.Generic;
using HK.Framework.EventSystems;
using HK.Ungya.Events.UI;
using HK.Ungya.GameSystems;
using HK.Ungya.ObjectPools;
using UniRx;
using UnityEngine;

namespace HK.Ungya.UI
{
    public sealed class WeaponListController : MonoBehaviour
    {
        [SerializeField]
        private Transform parent;
        
        [SerializeField]
        private WeaponElementController elementPrefab;

        private PoolManager.ComponentPool pool;
        
        private List<WeaponElementController> elements = new List<WeaponElementController>();

        void Awake()
        {
            this.pool = this.elementPrefab.GetPool();
        }

        public void Create()
        {
            var inventory = GameManager.Instance.Inventory;
            foreach (var weapon in inventory.Weapons)
            {
                var element = (WeaponElementController)this.pool.Rent();
                element.transform.SetParent(this.parent, false);
                element.Initialize(weapon);
                element.Button.OnClickAsObservable()
                    .TakeUntilDisable(element)
                    .Subscribe(_ => UniRxEvent.GlobalBroker.Publish(RequestPopup.GetCache("未実装のようだ...")))
                    .AddTo(element);
                this.elements.Add(element);
            }
        }

        public void Clear()
        {
            foreach (var element in this.elements)
            {
                this.pool.Return(element);
            }
            this.elements.Clear();
        }
    }
}
