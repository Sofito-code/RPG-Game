using Monobehavior.Personajes.Ataques;
using Portador.Implementaciones;
using UnityEngine;

namespace Habilidades.Implementacion
{
    [CreateAssetMenu(menuName = "Habilidades/DanoArea")]
    public class DanoArea : Habilidad
    {
        [SerializeField] private int dano = 10;
        public GameObject prefabZonaDano;
        public override void Usar(PortadorJugable portador)
        {
            base.Usar(portador);
            Vector3 origen = PuntoPartida.position;
            float distancia = 7f;
            Quaternion rotacion = PuntoPartida.rotation;

            Vector3 posicionFinal = origen + rotacion * Vector3.forward * distancia + new Vector3(0, 0.05f, 0);

            GameObject instanciaZonaDano = Instantiate(prefabZonaDano, posicionFinal, Quaternion.identity);
            instanciaZonaDano.GetComponent<AreaDano>().PuntosDaño = dano;
        }
    }
}