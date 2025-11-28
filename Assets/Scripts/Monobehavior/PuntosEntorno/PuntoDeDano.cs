using Monobehavior;
using System.Collections;
using UnityEngine;

public class PuntoDeDano : MonoBehaviour
{
    public int puntosDano = 10;
    Coroutine danoCoroutine;
    private void OnTriggerStay(Collider other)
    {
        if (danoCoroutine == null)
        {
            if (other.CompareTag("Player") && other.GetComponent<ControladorPJ>().Agente.Vida != 0)
            {
                danoCoroutine = StartCoroutine(HacerDano(other));
            }
        }
    }

    private IEnumerator HacerDano(Collider other)
    {
        if (danoCoroutine != null) yield break;
        other.GetComponent<ControladorPJ>().Agente.RecibirDano(puntosDano);
        Debug.Log("Vida despues de daño por punto de daño: " + other.GetComponent<ControladorPJ>().Agente.Vida);
        yield return new WaitForSeconds(2f);
        danoCoroutine = null;      
    }
}
