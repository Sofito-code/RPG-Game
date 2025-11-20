using Portador.Enum;

namespace Portador.Interfaces
{
    public interface IInteractuable
    {
        public Regeneracion TipoRegenMana { get; }
        public int Mana { get; }
        public void RegenerarMana(int puntosMana);
        public void UsarMana(int puntosMana);
    }
}
