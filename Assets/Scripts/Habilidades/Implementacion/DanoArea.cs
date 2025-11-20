using UnityEngine;

namespace Habilidades.Implementacion
{
    public class DanoArea : Habilidad
    {
        public DanoArea(string nombre, int tiempoCD, int puntosManaReq, Sprite icono) : base(nombre, tiempoCD, puntosManaReq, icono)
        {
            
        }

        public override void Usar()
        {
            Debug.Log("Usando daño area");
        }
    }
}