using UnityEngine;

namespace Monobehavior
{
    public class ControladorMovimiento : MonoBehaviour
    {
        public float velMovimiento = 6f;
        public float velRotacion = 100f;
        private Transform transformJugador;
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            // Ocultar y bloquear cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Auto-asignar transform
            if (transformJugador == null)
                transformJugador = transform;
        }

        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * velRotacion * Time.deltaTime;
            transformJugador.Rotate(Vector3.up * mouseX);
        }

        void FixedUpdate()
        {
            float x = Input.GetAxisRaw("Horizontal");  // A/D o flechas izq/der
            float z = Input.GetAxisRaw("Vertical");    // W/S o flechas arr/aba
            Vector3 move = (transform.right * x + transform.forward * z).normalized * velMovimiento;

            // Aplicar solo en XZ, preservar Y para gravedad/caídas
            rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
        }
    }
}