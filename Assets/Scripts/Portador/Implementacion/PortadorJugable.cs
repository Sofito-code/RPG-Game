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
            EstadistCambiadas = new UnityEvent();
            TipoRegenMana = Regeneracion.PorContacto;
            Mana = 100;
        }

        public PortadorJugable(string nombre, int vida, Regeneracion tipoRegenVida,
            int mana, Regeneracion tipoRegenMana)
            : base(nombre, vida, tipoRegenVida)
        {
            TipoRegenMana = tipoRegenMana;
            Mana = mana;
        }

        private void AgregarHabilidadesBasicas(Habilidad[] habs)
        {
            int cont = 0;
            Habilidad[] listaAux = new Habilidad[3];
            foreach (Habilidad hab in habs)
            {
                if (cont == 3)
                {
                    break;
                }
                if (hab != null)
                {
                    listaAux[cont++] = hab;
                }
            }
            _habilidades = listaAux;
        }
        
        public UnityEvent EstadistCambiadas
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

        public void UsarMana(int puntosMana)
        {
            Mana -= Mathf.Clamp(puntosMana, 0, 100);
        }
    }
}