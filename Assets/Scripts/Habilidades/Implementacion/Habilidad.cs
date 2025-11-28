using Habilidades.Enum;
using Habilidades.Interfaz;
using Portador.Implementaciones;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Habilidades.Implementacion
{
    public abstract class Habilidad : ScriptableObject, IUsable
    {
        [SerializeField] private string _nombre;
        [SerializeField] private int _puntosReq;
        [SerializeField] private Sprite _icono;
        [SerializeField] private UnityEvent _cambiadoEvent;
        [SerializeField] private int _tiempoCD;
        [SerializeField] private Estado _estado;
        [SerializeField] private GameObject _prefabUI;
        private Transform transformPadre;

        public int TiempoCD => _tiempoCD;

        public Transform TransformPadre
        {
            get => transformPadre;
            set => transformPadre = value;
        }
        public Estado Estado
        {
            get => _estado;
            set => _estado = value;
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public int PuntosReq
        {
            get => _puntosReq;
            set => _puntosReq = value;
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

        public virtual void Usar(PortadorJugable portador)
        {
            Debug.Log($"Agente: {portador.Nombre} Usando: {Nombre}");
            switch (portador.TipoCosto)
            {
                case TipoCosto.Mana:
                    portador.GastarMana(PuntosReq);
                    Debug.Log($"{portador.Nombre} ha gastado {PuntosReq} de mana y su mana ahora es {portador.Mana}");
                    Estado = Estado.EnEspera;
                    break;
                case TipoCosto.Vida:
                    portador.RecibirDano(PuntosReq);
                    Debug.Log($"{portador.Nombre} ha gastado {PuntosReq} de vida y su vida ahora es {portador.Vida}");
                    Estado = Estado.EnEspera;
                    break;
            }
        }
    }
}