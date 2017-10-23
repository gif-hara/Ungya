using HK.Framework.EventSystems;
using HK.Ungya.Events.UI;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HK.Ungya.UI
{
    [RequireComponent(typeof(Button))]
    public sealed class ExerciseButtonController : MonoBehaviour
    {
        void Awake()
        {
            var button = this.GetComponent<Button>();
            Assert.IsNotNull(button);
            button.OnClickAsObservable()
                .Where(_ => button.isActiveAndEnabled)
                .Subscribe(_ =>
                {
                    UniRxEvent.GlobalBroker.Publish(ChangeUI.GetCache(UIType.Exercise));
                })
                .AddTo(button);
        }
    }
}
