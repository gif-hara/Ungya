using System;
using System.Collections.Generic;
using HK.Framework.EventSystems;
using HK.Framework.Text;
using HK.Ungya.Events.UI;
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

        [SerializeField]
        private StringAsset.Finder skillName;

        [SerializeField]
        private StringAsset.Finder exerciseName;

        [SerializeField]
        private StringAsset.Finder sortName;
        
        [SerializeField]
        private StringAsset.Finder cancelName;

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
                this.CreateSkillParameter,
                this.CreateExerciseParameter
                );
        }

        private void ToExercise()
        {
            this.Setup(
                new ButtonParameter(this.sortName, () =>
                {
                    Debug.Log("TODO");
                }),
                new ButtonParameter(this.cancelName, () =>
                {
                    UniRxEvent.GlobalBroker.Publish(ChangeUI.GetCache(UIType.Main));
                })
                );
        }

        private ButtonParameter CreateExerciseParameter
        {
            get
            {
                return new ButtonParameter(this.exerciseName, () =>
                {
                    UniRxEvent.GlobalBroker.Publish(ChangeUI.GetCache(UIType.Exercise));
                });
            }
        }

        private ButtonParameter CreateSkillParameter
        {
            get
            {
                return new ButtonParameter(this.skillName, () =>
                {
                    Debug.Log("TODO");
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
