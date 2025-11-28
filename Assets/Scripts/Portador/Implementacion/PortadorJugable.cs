using Portador.Enum;
using Portador.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Portador.Implementaciones
{
    public class PortadorJugable : Portador, IInteractuable
    {
        private UnityEvent _estadistCambiadasEvent;
        private int _mana;
        private Regeneracion _tipoRegenMana;
        private TipoCosto tipoCosto;

        public PortadorJugable()
        {
            TipoRegenMana = Regeneracion.PorContacto;
            Mana = 100;
            EstadistCambiadasEvent = new UnityEvent();
        }

        public PortadorJugable(string nombre, int vida,
            int mana) : base(nombre, vida)
        {
            TipoRegenMana = Regeneracion.SinRegeneracion;
            Mana = mana;
            EstadistCambiadasEvent = new UnityEvent();
        }
        public TipoCosto TipoCosto
        {
            get => tipoCosto; protected set => tipoCosto = value;
        }

        public UnityEvent EstadistCambiadasEvent
        {
            get => _estadistCambiadasEvent;
            private set => _estadistCambiadasEvent = value;
        }

        public Regeneracion TipoRegenMana
        {
            get => _tipoRegenMana;
            private set => _tipoRegenMana = value;
        }

        public int Mana
        {
            get => _mana;
            protected set => _mana = Mathf.Clamp(value, 0, 100);
        }

        public void RegenerarMana(int puntosMana)
        {
            Mana += Mathf.Clamp(puntosMana, 0, 100);
        }

        public void GastarMana(int puntosMana)
        {
            Mana -= Mathf.Clamp(puntosMana, 0, 100);
        }
    }
}