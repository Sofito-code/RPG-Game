using System.Collections;
using UnityEngine;

namespace Monobehavior.Personajes.Ataques
{
    public class AreaDano : MonoBehaviour
    {
        [SerializeField] private int TiempoDeAtaque = 6;
        private int _puntosDano = 10;
        Coroutine danoCoroutine;

        public int PuntosDaño { get => _puntosDano; set => _puntosDano = value; }

        void Start()
        {
            StartCoroutine(IniciarTiempoAtaque());            
        }

        private void OnTriggerStay(Collider other)
        {
            if (danoCoroutine == null)
            {
                if (other.CompareTag("Enemigo") && other.GetComponent<ControladorPNJ>().NPC.Vida != 0)
                {
                    danoCoroutine = StartCoroutine(HacerDano(other));
                }
            }
        }
        private IEnumerator HacerDano(Collider other)
        {
            if (danoCoroutine != null) yield break;
            other.GetComponent<ControladorPNJ>().NPC.RecibirDano(_puntosDano);
            Debug.Log("Vida NPC despues de daño por area: " + other.GetComponent<ControladorPNJ>().NPC.Vida);
            yield return new WaitForSeconds(2f);
            danoCoroutine = null;
        }
        private IEnumerator IniciarTiempoAtaque()
        {
            yield return new WaitForSeconds(TiempoDeAtaque);
            Destroy(gameObject);
        }
    }
}