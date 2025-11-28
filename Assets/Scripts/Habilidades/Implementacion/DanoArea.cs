using Assets.Scripts.Monobehavior;
using Monobehavior;
using Portador.Implementaciones;
using System.Collections;
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
            Vector3 origen = TransformPadre.position;
            float distancia = 5f;
            Quaternion rotacion = TransformPadre.rotation;

            Vector3 posicionFinal = origen + rotacion * Vector3.forward * distancia + new Vector3(0, 0.05f, 0);

            GameObject instanciaZonaDano = Instantiate(prefabZonaDano, posicionFinal, Quaternion.identity);
            instanciaZonaDano.GetComponent<AreaDano>().PuntosDaño = dano;
        }
    }
}