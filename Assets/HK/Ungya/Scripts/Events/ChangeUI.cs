using HK.Framework.EventSystems;

namespace HK.Ungya.Events.UI
{
    /// <summary>
    /// UIを切り替える際のイベント
    /// </summary>
    public sealed class ChangeUI : UniRxEvent<ChangeUI, UIType>
    {
        public UIType UIType { get { return this.param1; } }
    }
}
