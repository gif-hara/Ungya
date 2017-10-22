using HK.Ungya.CharacterControllers;
using UniRx;

namespace HK.Ungya.StateMachines
{
    public abstract class State : IState
    {
        private CompositeDisposable duringStateStream;
        
        public virtual void OnEnter(StateMachine stateMachine, Character character)
        {
            
        }

        public virtual void OnExit()
        {
            this.duringStateStream.Dispose();
        }
    }
}
