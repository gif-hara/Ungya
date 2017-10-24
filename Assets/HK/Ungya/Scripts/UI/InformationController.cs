using System.Collections.Generic;
using DG.Tweening;
using HK.Framework.EventSystems;
using HK.Ungya.Events.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace HK.Ungya.UI
{
    public sealed class InformationController : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup canvasGroup;
        
        [SerializeField]
        private RectTransform background;

        [SerializeField]
        private Text message;

        [SerializeField]
        private float tweenDuration;

        [SerializeField]
        private Ease tweenEase;

        [SerializeField]
        private float fadeOutDelay;

        [SerializeField]
        private float fadeOutDelayQueue;

        [SerializeField]
        private float fadeInScale;

        [SerializeField]
        private float fadeOutScale;

        private Queue<string> requestMessages = new Queue<string>();

        private Sequence sequence;

        void Awake()
        {
            UniRxEvent.GlobalBroker.Receive<RequestInformation>()
                .SubscribeWithState(this, (r, _this) =>
                {
                    _this.Enqueue(r.Message);
                })
                .AddTo(this);
        }

        private void Enqueue(string message)
        {
            if (this.sequence == null)
            {
                this.StartTween(message);
            }
            else
            {
                this.requestMessages.Enqueue(message);
            }
        }

        private void StartTween(string message)
        {
            this.background.localScale = new Vector3(this.fadeInScale, this.fadeInScale, 1.0f);
            this.message.text = message;
            this.sequence = DOTween.Sequence()
                .Append(this.canvasGroup.DOFade(1.0f, this.tweenDuration).SetEase(this.tweenEase))
                .Join(this.background.DOScale(Vector3.one, this.tweenDuration).SetEase(this.tweenEase))
                .AppendInterval(this.requestMessages.Count <= 0 ? this.fadeOutDelay : this.fadeOutDelayQueue)
                .Append(this.canvasGroup.DOFade(0.0f, this.tweenDuration).SetEase(this.tweenEase))
                .Join(this.background.DOScale(new Vector3(this.fadeOutScale, this.fadeOutScale, 1.0f), this.tweenDuration).SetEase(this.tweenEase))
                .OnComplete(() =>
                {
                    if (this.requestMessages.Count > 0)
                    {
                        this.StartTween(this.requestMessages.Dequeue());
                    }
                    else
                    {
                        this.sequence = null;
                    }
                });
        }
    }
}
