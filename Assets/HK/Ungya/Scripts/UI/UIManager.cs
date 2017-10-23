using DG.Tweening;
using UnityEngine;

namespace HK.Ungya.UI
{
    public sealed class UIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject main;

        [SerializeField]
        private float tweenDutation;

        [SerializeField]
        private Ease tweenEase;

        public float TweenDutation { get { return this.tweenDutation; } }

        public Ease TweenEase { get { return this.tweenEase; } }
    }
}
