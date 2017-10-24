using DG.Tweening;
using DG.Tweening.Core;
using HK.Framework.EventSystems;
using HK.Ungya.Events.UI;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HK.Ungya.UI
{
    [RequireComponent(typeof(Button))]
    public sealed class PopupController : MonoBehaviour
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
        private float tweenPositionY;

        private Tweener tweener;
        
        void Awake()
        {
            var button = this.GetComponent<Button>();
            Assert.IsNotNull(button);

            button.OnClickAsObservable()
                .Where(_ => button.isActiveAndEnabled)
                .SubscribeWithState(this, (_, _this) =>
                {
                    _this.StartFadeOut();
                })
                .AddTo(this);
            
            UniRxEvent.GlobalBroker.Receive<RequestPopup>()
                .SubscribeWithState(this, (r, _this) =>
                {
                    _this.StartFadeIn(r.Message);
                })
                .AddTo(this);
        }

        private void StartFadeIn(string message)
        {
            KillTweener(this.tweener);
            this.canvasGroup.blocksRaycasts = true;
            this.canvasGroup.interactable = false;
            this.message.text = message;
            this.tweener = this.CreateTweener(x =>
            {
                this.canvasGroup.alpha = x;
                var position = this.background.anchoredPosition;
                position.y = Mathf.Lerp(this.tweenPositionY, 0.0f, x);
                this.background.anchoredPosition = position;
            }).OnComplete(() =>
            {
                this.canvasGroup.interactable = true;
            });
        }

        private void StartFadeOut()
        {
            KillTweener(this.tweener);
            this.canvasGroup.interactable = false;
            this.canvasGroup.blocksRaycasts = false;
            this.tweener = this.CreateTweener(x =>
            {
                this.canvasGroup.alpha = 1.0f - x;
                var position = this.background.anchoredPosition;
                position.y = Mathf.Lerp(0.0f, -this.tweenPositionY, x);
                this.background.anchoredPosition = position;
            });
        }

        private Tweener CreateTweener(DOSetter<float> setter)
        {
            return DOTween.To(() => 0.0f, setter, 1.0f, this.tweenDuration).SetEase(this.tweenEase);
        }

        private static void KillTweener(Tweener tweener)
        {
            if (tweener == null)
            {
                return;
            }
            
            tweener.Kill();
        }
    }
}
