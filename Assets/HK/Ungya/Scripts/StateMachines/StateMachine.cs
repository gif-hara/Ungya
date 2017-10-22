using HK.Ungya.CharacterControllers;
using UnityEngine.Assertions;

namespace HK.Ungya.StateMachines
{
    public sealed class StateMachine
    {
        private Character owner;
        
        public IState CurrentState { private set; get; }
        
        public StateMachine(Character owner, IState initialState)
        {
            this.owner = owner;
            Assert.IsNotNull(this.owner);
            this.Change(initialState);
        }

        public void Change(IState state)
        {
            if (this.CurrentState != null)
            {
                this.CurrentState.OnExit();
            }

            this.CurrentState = state;
            Assert.IsNotNull(this.CurrentState);
            
            this.CurrentState.OnEnter(this, this.owner);
        }
    }
}
