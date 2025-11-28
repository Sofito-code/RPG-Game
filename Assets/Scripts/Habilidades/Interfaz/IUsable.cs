using Habilidades.Enum;
using Portador.Implementaciones;

namespace Habilidades.Interfaz
{
    public interface IUsable
    {
        public int TiempoCD { get; }
        
        public Estado Estado { get; set; }

        public void Usar(PortadorJugable portador);
    }
}