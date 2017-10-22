using HK.Framework.EventSystems;
using HK.Ungya.CharacterControllers;

namespace HK.Ungya.Events.CharacterControllers
{
    public sealed class PlayerSpawned : UniRxEvent<PlayerSpawned, Character>
    {
        public Character Player { get { return this.param1; } }
    }
}
