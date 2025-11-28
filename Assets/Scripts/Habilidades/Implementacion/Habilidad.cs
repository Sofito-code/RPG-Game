using Habilidades.Enum;
using Habilidades.Interfaz;
using Portador.Enum;
using Portador.Implementaciones;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Habilidades.Implementacion
{
    public abstract class Habilidad : ScriptableObject, IUsable
    {
        [SerializeField] private string _nombre;
        [SerializeField] private int _puntosReq;
        [SerializeField] private Sprite _icono;
        [SerializeField] private int _tiempoCD;
        [SerializeField] private Estado _estado;
        private UnityEvent _cambiadoEvent = new UnityEvent();
        private Transform _transformPadre;
        private int _tiempoCDRestante = 0;
        private Coroutine _coroutineCD;

        private void OnEnable()
        {
            _estado = Estado.Disponible;
            _tiempoCDRestante = 0;
            _cambiadoEvent.RemoveAllListeners();
        }
        public int TiempoCD => _tiempoCD;

        public Coroutine CoroutineCD { get => _coroutineCD; set => _coroutineCD = value; }
        public Transform TransformPadre
        {
            get => _transformPadre;
            set => _transformPadre = value;
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

        public virtual void Usar(PortadorJugable portador)
        {
            Debug.Log($"Agente: {portador.Nombre} Usando: {Nombre}");
            switch (portador.TipoCosto)
            {
                case TipoCosto.Mana:
                    portador.GastarMana(PuntosReq);
                    Debug.Log($"{portador.Nombre} ha gastado {PuntosReq} de mana y su mana ahora es {portador.Mana}");
                    _estado = Estado.EnEspera;
                    break;
                case TipoCosto.Vida:
                    portador.RecibirDano(PuntosReq);
                    Debug.Log($"{portador.Nombre} ha gastado {PuntosReq} de vida y su vida ahora es {portador.Vida}");
                    _estado = Estado.EnEspera;
                    break;
            }
            portador.EstadistCambiadasEvent.Invoke();
        }

        public IEnumerator TiempoCorutinaCD()
        {
            _tiempoCDRestante = _tiempoCD;
            while (_tiempoCDRestante > 0)
            {
                _cambiadoEvent.Invoke();
                yield return new WaitForSeconds(1);
                _tiempoCDRestante--;
                _cambiadoEvent.Invoke();
            }
            _estado = Estado.Disponible;
            _coroutineCD = null;
        }

        public int TiempoRestanteCD()
        {
            return _tiempoCDRestante;
        }
    }
}