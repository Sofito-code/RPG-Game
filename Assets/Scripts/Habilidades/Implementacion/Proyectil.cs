using Monobehavior.Personajes.Ataques;
using Portador.Implementaciones;
using UnityEngine;

namespace Habilidades.Implementacion
{
    [CreateAssetMenu(menuName = "Habilidades/Proyectil")]
    public class Proyectil : Habilidad
    {
        [SerializeField] private int dano = 6;
        [SerializeField] private GameObject prefabProyectil;
        [SerializeField] private int fuerzaLanzamiento = 10;

        public override void Usar(PortadorJugable portador)
        {
            base.Usar(portador);
            Vector3 origen = TransformPadre.position;
            GameObject piedra = Instantiate(prefabProyectil, origen, Quaternion.identity);
            Rigidbody rb = piedra.GetComponent<PiedraProyectil>().RBody;
            piedra.GetComponent<PiedraProyectil>().Dano = dano;
            Vector3 direccion = TransformPadre.rotation * Vector3.forward;
            rb.AddForce(direccion.normalized * fuerzaLanzamiento, ForceMode.Impulse);
            //(rotación en vuelo)
            rb.AddTorque(Vector3.up * 5f + Vector3.right * 2f, ForceMode.Impulse);
        }
    }
}