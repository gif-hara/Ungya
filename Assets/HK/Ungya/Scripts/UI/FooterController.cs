using System;
using System.Collections.Generic;
using HK.Framework.EventSystems;
using HK.Framework.Text;
using HK.Ungya.Events.UI;
using HK.Ungya.GameSystems;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace HK.Ungya.UI
{
    public sealed class FooterController : MonoBehaviour
    {
        [SerializeField]
        private List<FooterButton> footerButtons;

        private List<Action> buttonActions = new List<Action>();

        void Awake()
        {
            for (int i = 0; i < this.footerButtons.Count; i++)
            {
                this.buttonActions.Add(null);

                var footerButton = this.footerButtons[i];
                footerButton.Button.OnClickAsObservable()
                    .Where(_ => footerButton.Button.isActiveAndEnabled)
                    .SubscribeWithState2(this, i, (_, _this, _i) =>
                    {
                        var action = _this.buttonActions[_i];
                        if (action != null)
                        {
                            action();
                        }
                    })
                    .AddTo(this);
            }

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
                })
                .AddTo(this);
        }

        public void Setup(params ButtonParameter[] parameters)
        {
            for (int i = 0; i < this.footerButtons.Count; i++)
            {
                this.footerButtons[i].Button.gameObject.SetActive(i < parameters.Length);
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                var buttonParameter = parameters[i];
                var footerButton = this.footerButtons[i];
                this.buttonActions[i] = buttonParameter.Action;
                footerButton.Text.text = buttonParameter.Name.Get;
            }
        }
        
        private void ToMain()
        {
            this.Setup(
                this.SkillParameter,
                this.ExerciseParameter,
                this.EquipmentParameter
                );
        }

        private void ToExercise()
        {
            this.Setup(
                // ソートボタン
                new ButtonParameter(UserInterfaceText.Instance.Sort, () =>
                {
                    UniRxEvent.GlobalBroker.Publish(RequestPopup.GetCache("未実装のようだ..."));
                }),
                this.CancelParameter
                );
        }

        private void ToEquipment()
        {
            this.Setup(
                // ソートボタン
                new ButtonParameter(UserInterfaceText.Instance.Sort, () =>
                {
                    UniRxEvent.GlobalBroker.Publish(RequestPopup.GetCache("未実装のようだ..."));
                }),
                this.CancelParameter
            );
        }

        /// <summary>
        /// 特技ボタンを作成する
        /// </summary>
        private ButtonParameter SkillParameter
        {
            get
            {
                return new ButtonParameter(UserInterfaceText.Instance.Skill, () =>
                {
                    UniRxEvent.GlobalBroker.Publish(RequestPopup.GetCache("未実装のようだ..."));
                });
            }
        }
        
        /// <summary>
        /// 鍛錬ボタンを作成する
        /// </summary>
        private ButtonParameter ExerciseParameter
        {
            get
            {
                return new ButtonParameter(UserInterfaceText.Instance.Exercise, () =>
                {
                    UniRxEvent.GlobalBroker.Publish(ChangeUI.GetCache(UIType.Exercise));
                });
            }
        }

        /// <summary>
        /// 装備ボタンを作成する
        /// </summary>
        private ButtonParameter EquipmentParameter
        {
            get
            {
                return new ButtonParameter(UserInterfaceText.Instance.Equipment, () =>
                {
                    UniRxEvent.GlobalBroker.Publish(ChangeUI.GetCache(UIType.Equipment));
                });
            }
        }

        private ButtonParameter CancelParameter
        {
            get
            {
                return new ButtonParameter(UserInterfaceText.Instance.Cancel, () =>
                {
                    UniRxEvent.GlobalBroker.Publish(ChangeUI.GetCache(UIType.Main));
                });
            }
        }

        [Serializable]
        public class FooterButton
        {
            public Button Button;

            public Text Text;
        }

        public class ButtonParameter
        {
            public StringAsset.Finder Name;

            public Action Action;

            public ButtonParameter(StringAsset.Finder name, Action action)
            {
                this.Name = name;
                this.Action = action;
            }
        }
    }
}
