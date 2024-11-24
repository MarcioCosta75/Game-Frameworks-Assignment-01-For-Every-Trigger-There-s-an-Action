using UnityEngine;
using Storytelling;

namespace Storytelling.Actions
{
    public abstract class VectorActionBehaviour : ActionBehaviour
    {
        public abstract void Act(Vector3 vector);
    }
}
