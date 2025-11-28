using Monobehavior;
using Portador.Implementaciones;
using System.Collections;
using UnityEngine;

public class PuntoCargaMana : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int puntosDano = 10;
    Coroutine curacionCoroutine;
    private PortadorJugable agente;
    private void OnTriggerStay(Collider other)
    {
        if (curacionCoroutine == null)
        {
            if (other.CompareTag("Player"))
            {
                agente = other.GetComponent<ControladorPJ>().Agente;
                if (agente.Mana < 100)
                    curacionCoroutine = StartCoroutine(CargarMana());

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (curacionCoroutine != null)
        {
            StopCoroutine(CargarMana());
            curacionCoroutine = null;
            agente = null;
        }

    }

    private IEnumerator CargarMana()
    {
        if (curacionCoroutine != null) yield break;
        agente.RegenerarMana(10);
        agente.EstadistCambiadasEvent.Invoke();
        Debug.Log("Mana Recargado: " + agente.Mana);
        yield return new WaitForSeconds(2f);
        curacionCoroutine = null;
    }
}
