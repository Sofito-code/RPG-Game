using UnityEngine;

namespace Habilidades.Implementacion
{
    public class Proyectil : Habilidad
    {
        public Proyectil(string nombre, int tiempoCD, int puntosReq, Sprite icono) : base(nombre, tiempoCD, puntosReq, icono)
        {
            
        }

        public override void Usar()
        {
            Debug.Log("Usando proyectil");
        }
    }
}