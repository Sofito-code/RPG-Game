using Portador.Enum;
using Portador.Implementaciones;

namespace Agente
{
    /**
     * Portador Jugable que gasta Maná
     */
    public class Agente2 : PortadorJugable
    {
        public Agente2(string nombre, int vida, int mana) : base(nombre, vida, mana)
        {
            TipoCosto = TipoCosto.Mana;
        }

    }
}