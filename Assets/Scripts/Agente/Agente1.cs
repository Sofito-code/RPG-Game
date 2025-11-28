using Portador.Enum;
using Portador.Implementaciones;
using UnityEngine;

namespace Agente
{
    /**
     * Portador Jugable que gasta Vida
     */
    public class Agente1: PortadorJugable
    {
        public Agente1(string nombre, int vida, int mana) : base(nombre, vida, mana)
        {
            TipoCosto = TipoCosto.Vida;
        }

    }
}