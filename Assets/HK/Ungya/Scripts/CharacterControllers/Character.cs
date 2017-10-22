using UniRx;
using UnityEngine;

namespace HK.Ungya.CharacterControllers
{
    public class Character : MonoBehaviour
    {
        public IMessageBroker Provider { private set; get; }

        void Awake()
        {
            this.Provider = new MessageBroker();
        }
    }
}
