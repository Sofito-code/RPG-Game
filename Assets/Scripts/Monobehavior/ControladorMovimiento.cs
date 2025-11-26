using UnityEngine;

namespace Monobehavior
{
    public class ControladorMovimiento : MonoBehaviour
    {
        public float velocidad = 5.0f;
        private Rigidbody rb;
        private Vector3 entradaMovimiento;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        
            // Importante: Congelar la rotación para que la cápsula/cubo no ruede por el suelo
            rb.freezeRotation = true; 
        }

        void Update()
        {
            // 1. LEER INPUTS (Siempre en Update)
            // Leemos las teclas aquí para que la respuesta sea instantánea
            float x = Input.GetAxisRaw("Horizontal"); // GetAxisRaw da un movimiento más "seco" y preciso
            float z = Input.GetAxisRaw("Vertical");

            entradaMovimiento = new Vector3(x, 0, z).normalized;
        }

        void FixedUpdate()
        {
            // 2. APLICAR FÍSICAS (Siempre en FixedUpdate)
        
            // Calculamos la nueva posición deseada
            // Usamos Time.fixedDeltaTime porque estamos dentro del ciclo de físicas
            Vector3 movimiento = entradaMovimiento * velocidad * Time.fixedDeltaTime;
        
            // MovePosition intenta mover el objeto allí, pero se detendrá si choca con algo
            rb.MovePosition(rb.position + movimiento);
        }
    }
}