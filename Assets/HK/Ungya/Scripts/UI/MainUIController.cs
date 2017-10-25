using System;
using DG.Tweening;
using HK.Framework.EventSystems;
using HK.Ungya.Events.UI;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ungya.UI
{
    public sealed class MainUIController : MonoBehaviour
    {
        [SerializeField]
        private MainUITransform mainTransform;

        [SerializeField]
        private MainUITransform otherTransform;

        [SerializeField]
        private UIManager uiManager;

        [SerializeField]
        private WeaponListController weaponListController;

        private RectTransform cachedTransform;

        private Tweener transformTweener = null;
        
        void Awake()
        {
            this.cachedTransform = (RectTransform) this.transform;
            
            UniRxEvent.GlobalBroker.Receive<ChangeUI>()
                .SubscribeWithState(this, (c, _this) =>
                {
                    if (c.UIType == UIType.Main)
                    {
                        _this.ToMain();
                    }
                    else if (c.UIType == UIType.Exercise)
                    {
                        _this.ToExercise();
                    }
                    else if (c.UIType == UIType.Equipment)
                    {
                        _this.ToEquipment();
                    }
                    else
                    {
                        Assert.IsTrue(false, string.Format("未対応の値です {0}", c.UIType));
                    }
                })
                .AddTo(this);
        }

        private void ToMain()
        {
            this.StartTween(this.mainTransform);
            this.weaponListController.Clear();
        }

        private void ToExercise()
        {
            this.StartTween(this.otherTransform);
        }

        private void ToEquipment()
        {
            this.StartTween(this.otherTransform);
            this.weaponListController.Create();
        }

        private void StartTween(MainUITransform transform)
        {
            if (this.transformTweener != null)
            {
                this.transformTweener.Kill();
            }

            this.transformTweener = transform.Transform(this.cachedTransform, this.uiManager.TweenDutation, this.uiManager.TweenEase);
        }

        [Serializable]
        public class MainUITransform
        {
            [SerializeField]
            private float positionY;

            public Tweener Transform(RectTransform target, float duration, Ease ease)
            {
                var fromPositionY = target.anchoredPosition.y;
                return DOTween.To(() => 0.0f, x =>
                        {
                            var position = target.anchoredPosition;
                            position.y = Mathf.Lerp(fromPositionY, this.positionY, x);
                            target.anchoredPosition = position;
                        },
                        1.0f,
                        duration)
                    .SetEase(ease);
            }
        }
    }
}
