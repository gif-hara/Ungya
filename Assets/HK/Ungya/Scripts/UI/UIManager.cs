using DG.Tweening;
using HK.Framework.EventSystems;
using HK.Ungya.Events.UI;
using UnityEngine;

namespace HK.Ungya.UI
{
    public sealed class UIManager : MonoBehaviour
    {
        [SerializeField]
        private float tweenDutation;

        [SerializeField]
        private Ease tweenEase;

        public float TweenDutation { get { return this.tweenDutation; } }

        public Ease TweenEase { get { return this.tweenEase; } }

        void Start()
        {
            // 最初のUIタイプを発行する
            UniRxEvent.GlobalBroker.Publish(ChangeUI.GetCache(UIType.Main));
        }
    }
}
