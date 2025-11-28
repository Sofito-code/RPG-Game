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
        public Habilidad habilidad1;
        public Habilidad habilidad2;
        public Habilidad habilidad3;
        [SerializeField] private Transform _refDañoArea;
        [SerializeField] private Transform _refProyectil;

        void Start()
        {
            _agente = new Agente1("Agente1", 100, 50);
            habilidad1.TransformPadre = _refProyectil;
            habilidad3.TransformPadre = _refDañoArea;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (ValidarUsoHabilidad(habilidad1)) habilidad1.Usar(_agente);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                habilidad2.Usar(_agente);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (ValidarUsoHabilidad(habilidad3)) habilidad3.Usar(_agente);
            }
        }

        public PortadorJugable Agente { get => _agente; set => _agente = value; }

        /**
         * Valida si el agente tiene los recursos necesarios para usar la habilidad
         */
        private bool ValidarUsoHabilidad(Habilidad hab)
        {
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
    }
}