using UnityEngine;

namespace Habilidades.Implementacion
{
    public class AutoCuracion : Habilidad
    {
        public AutoCuracion(string nombre, int tiempoCD, int puntosReq, Sprite icono) : base(nombre, tiempoCD, puntosReq, icono)
        {
        }

        public override void Usar()
        {
            Debug.Log("Usando auto curacion");
        }
    }
}