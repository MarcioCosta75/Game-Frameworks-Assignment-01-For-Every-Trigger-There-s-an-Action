using UnityEngine;
using Storytelling;
using Storytelling.Actions;

namespace Storytelling.Triggers
{
    public abstract class VectorTriggerBehaviour : TriggerBehaviour
    {
        // Método abstrato para obter o Vector3.
        public abstract Vector3 GetVector();

        // Método adicional para processar Vector3 e acionar ações.
        protected void PerformVectorActions()
        {
            Vector3 vector = GetVector();
            foreach (ActionBehaviour action in actions)
            {
                // Verifica se a ação é um VectorActionBehaviour.
                if (action is VectorActionBehaviour vectorAction)
                {
                    vectorAction.Act(vector);
                }
            }
        }

        // Sobrescreve CheckTriggered para incluir o processamento de Vector3.
        public override void CheckTriggered()
        {
            base.CheckTriggered(); // Executa as ações padrão.
            PerformVectorActions(); // Adiciona lógica para processar Vector3.
        }
    }
}
