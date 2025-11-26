using UnityEngine;

namespace Habilidades.Implementacion
{
    public class DanoArea : Habilidad
    {
        public DanoArea(string nombre, int tiempoCD, int puntosReq, Sprite icono) : base(nombre, tiempoCD, puntosReq, icono)
        {
            
        }

        public override void Usar()
        {
            Debug.Log("Usando daño area");
        }
    }
}