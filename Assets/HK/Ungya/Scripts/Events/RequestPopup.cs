using HK.Framework.EventSystems;

namespace HK.Ungya.Events.UI
{
    public sealed class RequestPopup : UniRxEvent<RequestPopup, string>
    {
        public string Message { get { return this.param1; } }
    }
}
