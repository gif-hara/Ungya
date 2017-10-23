using HK.Framework.EventSystems;
using HK.Ungya.CharacterControllers;

namespace HK.Ungya.Events.CharacterControllers
{
    public sealed class EnemySpawned : UniRxEvent<EnemySpawned, Character>
    {
        public Character Enemy { get { return this.param1; } }
    }
}
