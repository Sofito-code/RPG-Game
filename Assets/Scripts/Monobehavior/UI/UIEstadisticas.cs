using Monobehavior;
using Monobehavior.Personajes;
using Portador.Implementaciones;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Monobehavior.UI
{
    public class UIEstadisticas : MonoBehaviour
    {
        [SerializeField] private GameObject jugadorGO;
        [SerializeField] private Text _textoVida;
        [SerializeField] private Image _barraVida;
        [SerializeField] private Image _barraMana;
        [SerializeField] private Image _icono;

        [SerializeField] private List<Sprite> _iconos = new List<Sprite>();
        private PortadorJugable _jugador;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ControladorPJ controlador = jugadorGO.GetComponent<ControladorPJ>();
            if (controlador.TipoAgente == 0)
                _icono.sprite = _iconos[0];
            else
                _icono.sprite = _iconos[1];

            _jugador = controlador.Agente;
            _jugador.EstadistCambiadasEvent.AddListener(ActualizarEstadisticas);
            _jugador.EstadistCambiadasEvent.Invoke();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void ActualizarEstadisticas()
        {
            _textoVida.text = _jugador.Vida.ToString() + " / 100";
            _barraVida.fillAmount = (float)_jugador.Vida / 100;
            _barraMana.fillAmount = (float)_jugador.Mana / 100;
        }
    }
}
