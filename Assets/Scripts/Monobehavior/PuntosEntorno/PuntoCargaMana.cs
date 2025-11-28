using Monobehavior;
using System.Collections;
using UnityEngine;

public class PuntoCargaMana : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int puntosDano = 10;
    Coroutine curacionCoroutine;
    private void OnTriggerStay(Collider other)
    {
        if (curacionCoroutine == null)
        {
            if (other.CompareTag("Player") && other.GetComponent<ControladorPJ>().Agente.Mana < 100)
            {
                curacionCoroutine = StartCoroutine(CargarMana(other));

            }
        }
    }

    private IEnumerator CargarMana(Collider other)
    {
        if (curacionCoroutine != null) yield break;
        other.GetComponent<ControladorPJ>().Agente.RegenerarMana(10);
        Debug.Log("Mana Recargado: " + other.GetComponent<ControladorPJ>().Agente.Mana);
        yield return new WaitForSeconds(2f);
        curacionCoroutine = null;
    }
}
