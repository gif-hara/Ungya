using HK.Framework.Text;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ungya.GameSystems
{
    public sealed class UserInterfaceText : MonoBehaviour
    {
        private static UserInterfaceText instance;
        public static UserInterfaceText Instance { get { return instance; } }

        /// <summary>
        /// アイテムを取得
        /// </summary>
        public StringAsset.Finder AcquireItem;

        /// <summary>
        /// 特技
        /// </summary>
        public StringAsset.Finder Skill;

        /// <summary>
        /// 鍛錬
        /// </summary>
        public StringAsset.Finder Exercise;

        /// <summary>
        /// 装備
        /// </summary>
        public StringAsset.Finder Equipment;

        /// <summary>
        /// 整頓
        /// </summary>
        public StringAsset.Finder Sort;

        /// <summary>
        /// 戻る
        /// </summary>
        public StringAsset.Finder Cancel;
        
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
