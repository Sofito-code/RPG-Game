using Habilidades.Implementacion;
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
        private Habilidad[] _habilidades = new Habilidad[3];

        public PortadorJugable()
        {
            TipoRegenMana = Regeneracion.PorContacto;
            Mana = 100;
            EstadistCambiadasEvent = new UnityEvent();
            AsignarHabilidades();
        }

        public PortadorJugable(string nombre, int vida, Regeneracion tipoRegenVida,
            int mana, Regeneracion tipoRegenMana)
            : base(nombre, vida, tipoRegenVida)
        {
            TipoRegenMana = tipoRegenMana;
            Mana = mana;
            EstadistCambiadasEvent = new UnityEvent();
            AsignarHabilidades();
        }
        
        public UnityEvent EstadistCambiadasEvent
        {
            get => _estadistCambiadasEvent;
            private set => _estadistCambiadasEvent = value;
        }

        private void AsignarHabilidades()
        {
            Proyectil hab1 = new Proyectil("Tridente", 3, 10, null);
            DanoArea hab2 = new DanoArea("Posion arrojadiza", 5, 20, null);
            AutoCuracion hab3 = new AutoCuracion("Manifestar", 10, 5, null);
            _habilidades = new Habilidad[] { hab1, hab2, hab3 };
        }

        public Habilidad[] Habilidades => _habilidades;
        

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

        public virtual void UsarHabilidad(int indexHabilidad)
        {
            Habilidades[indexHabilidad].Usar();
        }

    }
}