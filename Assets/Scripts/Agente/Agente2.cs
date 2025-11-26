using Portador.Enum;
using Portador.Implementaciones;

namespace Agente
{
    /**
     * Portador Jugable que gasta Maná
     */
    public class Agente2: PortadorJugable
    {
        public Agente2(string nombre, int vida, Regeneracion tipoRegenVida, int mana, Regeneracion tipoRegenMana) :
            base(nombre, vida, tipoRegenVida, mana, tipoRegenMana)
        {
            
        }

        public override void UsarHabilidad(int indexHabilidad)
        {
            base.UsarHabilidad(indexHabilidad);
            GastarMana(Habilidades[indexHabilidad].PuntosReq);
        }
    }
}