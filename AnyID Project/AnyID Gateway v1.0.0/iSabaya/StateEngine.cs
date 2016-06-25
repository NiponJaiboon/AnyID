using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSabaya
{
    public delegate void TransitionEventHandler(Context context, PersistentStatefulEntity statefulEntity, string reference, string remark);
    public delegate void StateEventHandler(Context context, PersistentStatefulEntity statefulEntity);

    public class StateEngine
    {
        public StateEngine(string title, State initialState, State[] states)
        {
            this.Title = title;
            this.InitialState = initialState;
            this.States = states;
        }

        public void Transit(Context context, PersistentStatefulEntity statefulEntity, string reference, string remark, int transitionEvent)
        {
            State s;
            if (statefulEntity.CurrentState == null)
                s = InitialState;
            else
                s = States[statefulEntity.CurrentState.StateCategory];
            try
            {

                var evh = s.TransitionEventHandlers[transitionEvent];
                if (evh == null)
                    throw new Exception(Title + " No event handler : " + statefulEntity.CurrentState.StateCategory + ", " + transitionEvent);
                s.TransitionEventHandlers[transitionEvent](context, statefulEntity, reference, remark);
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exception(Title + " Index out of range : " + statefulEntity.CurrentState.StateCategory + ", " + transitionEvent);
            }
        }

        public string GetStateCategoryDisplayName(int stateCategory)
        {
            return States[stateCategory].DisplayName;
        }

        public State GetStateCategoryInfo(int stateCategory)
        {
            return States[stateCategory];
        }

        public string Title { get; set; }
        private State InitialState { get; set; }
        //private TransitionEventHandler InitialStateHandler { get; set; }
        private State[] States { get; set; }
    }
}
