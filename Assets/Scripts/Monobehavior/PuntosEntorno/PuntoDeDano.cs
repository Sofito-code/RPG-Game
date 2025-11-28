using Monobehavior.Personajes;
using Portador.Implementaciones;
using System.Collections;
using UnityEngine;

namespace Monobehavior.PuntosEntorno
{
    public class PuntoDeDano : MonoBehaviour
    {
        public int puntosDano = 10;
        Coroutine danoCoroutine;
        private PortadorJugable agente;
        private void OnTriggerStay(Collider other)
        {
            if (danoCoroutine == null)
            {
                if (other.CompareTag("Player"))
                {
                    agente = other.GetComponent<ControladorPJ>().Agente;
                    if (agente.Vida != 0)
                        danoCoroutine = StartCoroutine(HacerDano());
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (danoCoroutine != null)
            {
                StopCoroutine(HacerDano());
                danoCoroutine = null;
                agente = null;
            }
        }

        private IEnumerator HacerDano()
        {
            if (danoCoroutine != null) yield break;
            agente.RecibirDano(puntosDano);
            agente.EstadistCambiadasEvent.Invoke();
            Debug.Log("Vida despues de daño por punto de daño: " + agente.Vida);
            yield return new WaitForSeconds(2f);
            danoCoroutine = null;
        }
    }
}