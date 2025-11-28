using Agente;
using Habilidades.Implementacion;
using Portador.Enum;
using Portador.Implementaciones;
using UnityEngine;

namespace Monobehavior
{
    public class ControladorPJ : MonoBehaviour
    {
        private PortadorJugable _agente;
        [SerializeField] private int _tipoAgente = 0;
        [SerializeField] private Habilidad habilidad1;
        [SerializeField] private Habilidad habilidad2;
        [SerializeField] private Habilidad habilidad3;
        [SerializeField] private Transform _refDañoArea;
        [SerializeField] private Transform _refProyectil;
        private GameObject _meshPersonaje;

        void Start()
        {
            _meshPersonaje = this.transform.GetChild(1).gameObject;
            if (_tipoAgente == 0)
            {
                _agente = new Agente1("Usopp", 100, 50);
                _meshPersonaje.transform.GetChild(1).gameObject.SetActive(true);
                _meshPersonaje.transform.GetChild(4).gameObject.SetActive(false);
            }
            else
            {
                _agente = new Agente2("Zoro", 100, 80);
                _meshPersonaje.transform.GetChild(4).gameObject.SetActive(true);
                _meshPersonaje.transform.GetChild(1).gameObject.SetActive(false);
            }
            habilidad1.TransformPadre = _refProyectil;
            habilidad3.TransformPadre = _refDañoArea;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (ValidarUsoHabilidad(habilidad1)) UsarHabilidad(habilidad1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (ValidarUsoHabilidad(habilidad2)) UsarHabilidad(habilidad2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (ValidarUsoHabilidad(habilidad3)) UsarHabilidad(habilidad3);
            }
        }

        public PortadorJugable Agente { get => _agente; set => _agente = value; }

        /**
         * Valida si el agente tiene los recursos necesarios para usar la habilidad
         */
        private bool ValidarUsoHabilidad(Habilidad hab)
        {
            if (hab.Estado == Habilidades.Enum.Estado.EnEspera || hab.CoroutineCD != null) return false;
            if (hab.Equals(habilidad2)) return true;
            switch (_agente.TipoCosto)
            {
                case TipoCosto.Vida:
                    if (_agente.Vida >= hab.PuntosReq)
                    {
                        return true;
                    }
                    break;
                case TipoCosto.Mana:
                    if (_agente.Mana >= hab.PuntosReq)
                    {
                        return true;
                    }
                    break;
            }
            Debug.Log("No tienes suficiente Mana/Vida");
            return false;
        }

        private void UsarHabilidad(Habilidad hab)
        {
            hab.Usar(_agente);
            hab.CoroutineCD = StartCoroutine(hab.TiempoCorutinaCD());
        }
    }
}