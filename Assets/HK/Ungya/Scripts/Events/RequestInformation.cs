using HK.Framework.EventSystems;

namespace HK.Ungya.Events.UI
{
    public sealed class RequestInformation : UniRxEvent<RequestInformation, string>
    {
        public string Message { get { return this.param1; } }
    }
}
