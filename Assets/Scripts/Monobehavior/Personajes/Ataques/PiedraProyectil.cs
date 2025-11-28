
using System.Collections;
using UnityEngine;

namespace Monobehavior.Personajes.Ataques
{
    public class PiedraProyectil : MonoBehaviour
    {
        [SerializeField] private int puntosDano = 4;
        private Coroutine tiempoCoroutine;
        int tiempoDestruccion = 5;
        private Rigidbody rb;
        public Rigidbody RBody { get => rb; }
        public int Dano { get => puntosDano; set => puntosDano = value; }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }


        private void OnCollisionEnter(Collision collision)
        {
            GameObject other = collision.gameObject;
            if (other.CompareTag("Enemigo") && other.GetComponent<ControladorPNJ>().NPC.Vida != 0)
            {
                HacerDano(other);
            }
            tiempoCoroutine = StartCoroutine(IniciarTiempoDestruccion());
        }


        private void HacerDano(GameObject other)
        {
            other.GetComponent<ControladorPNJ>().NPC.RecibirDano(puntosDano);
            Debug.Log("Vida NPC despues de daño por proyectil: " + other.GetComponent<ControladorPNJ>().NPC.Vida);
        }

        private IEnumerator IniciarTiempoDestruccion()
        {
            yield return new WaitForSeconds(tiempoDestruccion);
            Destroy(gameObject);
        }


    }
}


