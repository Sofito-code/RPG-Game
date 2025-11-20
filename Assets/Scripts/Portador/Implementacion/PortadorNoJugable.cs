using Portador.Enum;

namespace Portador.Implementaciones
{
    public class PortadorNoJugable : Portador
    {
        public PortadorNoJugable(string nombre, int vida, Regeneracion tipoRegenVida)
            : base(nombre, vida, tipoRegenVida)
        {
        }
    }
}