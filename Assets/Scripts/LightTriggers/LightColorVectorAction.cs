using UnityEngine;

namespace Storytelling.Actions
{
    public class LightColorVectorAction : VectorActionBehaviour
    {
        public Light targetLight;
        public float redScale = 1f;
        public float greenScale = 1f;
        public float blueScale = 1f;

        public override void Act(Vector3 vector)
        {
            if (targetLight == null) return;

            float red = Mathf.Clamp(vector.x * redScale, 0, 1);
            float green = Mathf.Clamp(vector.y * greenScale, 0, 1);
            float blue = Mathf.Clamp(vector.z * blueScale, 0, 1);

            targetLight.color = new Color(red, green, blue);
        }
    }
}
