using UnityEngine;
using Storytelling;
using Storytelling.Actions;

namespace Storytelling.Triggers
{
    public abstract class VectorTriggerBehaviour : TriggerBehaviour
    {
        // M�todo abstrato para obter o Vector3.
        public abstract Vector3 GetVector();

        // M�todo adicional para processar Vector3 e acionar a��es.
        protected void PerformVectorActions()
        {
            Vector3 vector = GetVector();
            foreach (ActionBehaviour action in actions)
            {
                // Verifica se a a��o � um VectorActionBehaviour.
                if (action is VectorActionBehaviour vectorAction)
                {
                    vectorAction.Act(vector);
                }
            }
        }

        // Sobrescreve CheckTriggered para incluir o processamento de Vector3.
        public override void CheckTriggered()
        {
            base.CheckTriggered(); // Executa as a��es padr�o.
            PerformVectorActions(); // Adiciona l�gica para processar Vector3.
        }
    }
}
