using Portador.Enum;
using Portador.Interfaces;
using UnityEngine;

namespace Portador.Implementaciones
{
    public abstract class Portador : IDanable
    {
        private string _nombre;
        private int _vida;

        public Portador()
        {
            Nombre = "Portador";
            Vida = 100;
        }

        public Portador(string nombre, int vida)
        {
            Nombre = nombre;
            Vida = Mathf.Clamp(vida, 0, 100);
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