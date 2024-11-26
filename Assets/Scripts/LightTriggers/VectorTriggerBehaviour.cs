using UnityEngine;
using Storytelling;
using Storytelling.Actions;

namespace Storytelling.Triggers
{
    public abstract class VectorTriggerBehaviour : TriggerBehaviour
    {
        public abstract Vector3 GetVector();

        protected void PerformVectorActions()
        {
            Vector3 vector = GetVector();
            foreach (ActionBehaviour action in actions)
            {
                if (action is VectorActionBehaviour vectorAction)
                {
                    vectorAction.Act(vector);
                }
            }
        }

        public override void CheckTriggered()
        {
            base.CheckTriggered();
            PerformVectorActions();
        }
    }
}
