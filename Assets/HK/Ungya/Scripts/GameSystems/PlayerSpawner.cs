using HK.Ungya.CharacterControllers;
using UnityEngine;

namespace HK.Ungya.GameSystems
{
    public sealed class PlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        private Character character;

        void Start()
        {
            Instantiate(this.character);
        }
    }
}
