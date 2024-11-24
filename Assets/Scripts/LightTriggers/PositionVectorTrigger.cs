using UnityEngine;

namespace Storytelling.Triggers
{
    public class PositionVectorTrigger : VectorTriggerBehaviour
    {
        private Vector3 initialPosition;

        private void Start()
        {
            if (initiator != null)
            {
                initialPosition = initiator.transform.position;
            }
        }

        public override Vector3 GetVector()
        {
            if (initiator == null) return Vector3.zero;
            return initiator.transform.position - initialPosition;
        }

        private void FixedUpdate()
        {
            CheckTriggered();
        }
    }
}
