using HK.Ungya.CharacterControllers;

namespace HK.Ungya.StateMachines
{
    public interface IState
    {
        void OnEnter(StateMachine stateMachine, Character character);

        void OnExit();
    }
}
