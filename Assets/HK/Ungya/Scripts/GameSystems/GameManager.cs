using HK.Ungya.CharacterControllers;
using HK.Ungya.Items;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ungya.GameSystems
{
    public sealed class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance { get { return instance; } }

        [SerializeField]
        private CharacterSpec characterSpec;
        public CharacterSpec CharacterSpec { get { return this.characterSpec; } }

        [SerializeField]
        private ItemSpec itemSpec;
        public ItemSpec ItemSpec { get { return this.itemSpec; } }

        [SerializeField]
        private ItemDropTable itemDropTable;
        public ItemDropTable ItemDropTable { get { return this.itemDropTable; } }

        void Awake()
        {
            Assert.IsNull(instance);
            instance = this;
        }

        void OnDestroy()
        {
            Assert.IsNotNull(instance);
            instance = null;
        }
    }
}
