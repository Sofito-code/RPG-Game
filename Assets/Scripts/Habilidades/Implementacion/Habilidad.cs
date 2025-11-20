using Habilidades.Enum;
using Habilidades.Interfaz;
using UnityEngine;
using UnityEngine.Events;

namespace Habilidades.Implementacion
{
    public abstract class Habilidad : IUsable
    {
        private string _nombre;
        private int _tiempoCD;
        private Estado _estado;
        private int _puntosManaReq;
        private Sprite _icono;
        private UnityEvent _cambiadoEvent;
        private GameObject _prefabUI;

        public Habilidad(string nombre, int tiempoCD, int puntosManaReq, Sprite icono)
        {
            _nombre = nombre;
            _tiempoCD = tiempoCD;
            _puntosManaReq = puntosManaReq;
            _icono = icono;
            _estado = Estado.Disponible;
            _cambiadoEvent = new UnityEvent();
        }

        public int TiempoCD => _tiempoCD;

        public Estado Estado
        {
            get => _estado;
            set => _estado = value; //agragar control
        }
        
        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public int PuntosManaReq
        {
            get => _puntosManaReq;
            set => _puntosManaReq = value;
        }

        public Sprite Icono
        {
            get => _icono;
            set => _icono = value;
        }

        public UnityEvent Cambiado
        {
            get => _cambiadoEvent;
            set => _cambiadoEvent = value;
        }

        public GameObject PrefabUI
        {
            get => _prefabUI;
            set => _prefabUI = value;
        }

        public abstract void Usar();
    }
}