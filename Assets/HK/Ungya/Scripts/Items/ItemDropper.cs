using System.Collections.Generic;
using HK.Ungya.CharacterControllers;

namespace HK.Ungya.Items
{
    public sealed class ItemDropper
    {
        public static List<Item> Drop(Character character, ItemDropTable dropTable, ItemSpec spec)
        {
            var characterTable = dropTable.Get(character.Status.Base.NameHash);
            if (characterTable == null)
            {
                return null;
            }
            return characterTable.Lottery(spec);
        }
    }
}
