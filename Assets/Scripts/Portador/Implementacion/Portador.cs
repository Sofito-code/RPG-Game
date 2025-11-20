using Portador.Enum;
using Portador.Interfaces;
using UnityEngine;

namespace Portador.Implementaciones
{
    public abstract class Portador : IDanable
    {
        private string _nombre;
        private int _vida;
        private Regeneracion _tipoRegenVida;

        public Portador()
        {
            Nombre = "Portador";
            TipoRegenVida = Regeneracion.PorContacto;
            Vida = 100;
        }

        public Portador(string nombre, int vida, Regeneracion tipoRegenVida)
        {
            Nombre = nombre;
            Vida = Mathf.Clamp(vida, 0, 100);
            TipoRegenVida = tipoRegenVida;
        }

        public Regeneracion TipoRegenVida
        {
            get => _tipoRegenVida;
            private set => _tipoRegenVida = value;
        }

        public int Vida
        {
            get => _vida;
            protected set => _vida = Mathf.Clamp(value, 0, 100);
        }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _nombre = value;
                }
            }
        } 
        
        //TO DO: Mejorar rango admitido para los putnos de daño 
        public void RecibirDano(int puntosDano)
        {
            Vida -= Mathf.Clamp(puntosDano, 0, 100);
        }

        public void RecibirSanacion(int puntosSanacion)
        {
            Vida += Mathf.Clamp(puntosSanacion, 0, 100);
        }
    }
}