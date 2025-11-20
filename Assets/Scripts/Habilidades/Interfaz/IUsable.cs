using Habilidades.Enum;

namespace Habilidades.Interfaz
{
    public interface IUsable
    {
        public int TiempoCD { get; }
        
        public Estado Estado { get; set; }

        public void Usar();
    }
}