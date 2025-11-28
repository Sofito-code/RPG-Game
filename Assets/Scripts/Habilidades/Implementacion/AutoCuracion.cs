using Portador.Implementaciones;
using UnityEngine;
using Portador.Enum;

namespace Habilidades.Implementacion
{
    [CreateAssetMenu(menuName = "Habilidades/Curar")]
    public class AutoCuracion : Habilidad
    {
        public int cantidadCura = 100;

        public override void Usar(PortadorJugable portador)
        {
            if (portador.TipoCosto == TipoCosto.Mana)
            {
                base.Usar(portador);
            }
            portador.RecibirSanacion(cantidadCura);
            portador.EstadistCambiadasEvent.Invoke();
            Debug.Log("Vida despues de curacion: " + portador.Vida);
        }
    }
}