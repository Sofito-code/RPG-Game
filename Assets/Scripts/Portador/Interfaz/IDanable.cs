using Portador.Enum;

namespace Portador.Interfaces
{
    public interface IDanable
    {
        public int Vida { get; }
        public void RecibirDano(int puntosDano);
        public void RecibirSanacion(int puntosSanacion);
    }
}
