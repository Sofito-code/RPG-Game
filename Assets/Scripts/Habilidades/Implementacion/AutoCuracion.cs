using UnityEngine;

namespace Habilidades.Implementacion
{
    public class AutoCuracion : Habilidad
    {
        public AutoCuracion(string nombre, int tiempoCD, int puntosManaReq, Sprite icono) : base(nombre, tiempoCD, puntosManaReq, icono)
        {
        }

        public override void Usar()
        {
            Debug.Log("Usando auto curacion");
        }
    }
}