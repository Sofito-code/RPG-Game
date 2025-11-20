using UnityEngine;

namespace Habilidades.Implementacion
{
    public class Proyectil : Habilidad
    {
        public Proyectil(string nombre, int tiempoCD, int puntosManaReq, Sprite icono) : base(nombre, tiempoCD, puntosManaReq, icono)
        {
            
        }

        public override void Usar()
        {
            Debug.Log("Usando proyectil");
        }
    }
}