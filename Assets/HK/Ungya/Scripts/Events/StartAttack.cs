using HK.Framework.EventSystems;
using HK.Ungya.CharacterControllers;

namespace HK.Ungya.Events.CharacterControllers
{
    public sealed class StartAttack : UniRxEvent<StartAttack, Character>
    {
        public Character Target { get { return this.param1; } }
    }
}
