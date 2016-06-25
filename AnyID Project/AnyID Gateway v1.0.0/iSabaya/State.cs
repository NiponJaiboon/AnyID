using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSabaya
{
    //public delegate bool GuardCondition(PersistentStatefulEntity entity, int transitionEvent);

    //public class SimpleTransitionEventHandler
    //{
    //    public TransitionEventHandler eventHandler;
    //    public virtual void Eval()
    //    {

    //    }
    //}

    //public class GuardedTransitionEventHandler : SimpleTransitionEventHandler
    //{
    //    public GuardCondition guardCondition;
    //    //TransitionEventHandler eventHandler;
    //}

    public struct State
    {
        public State(int stateCategory, bool isFinal, string displayName, TransitionEventHandler[] eventHandlers)
        {
            this.IsFinal = isFinal;
            this.StateCategory = stateCategory;
            this.DisplayName = displayName;
            this.TransitionEventHandlers = eventHandlers;
        }

        public int StateCategory;
        public string DisplayName;
        public bool IsFinal;
        public TransitionEventHandler[] TransitionEventHandlers;
        //public StateEventHandler EntryEventHandler;
        //public StateEventHandler ExitEventHandler;
    }
}
