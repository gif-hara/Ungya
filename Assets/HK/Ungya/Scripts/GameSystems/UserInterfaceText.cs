using HK.Framework.Text;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ungya.GameSystems
{
    public sealed class UserInterfaceText : MonoBehaviour
    {
        private static UserInterfaceText instance;
        public static UserInterfaceText Instance { get { return instance; } }

        public StringAsset.Finder AcquireItem;
        
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
