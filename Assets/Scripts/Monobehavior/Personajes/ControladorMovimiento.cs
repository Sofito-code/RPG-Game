using UnityEngine;

namespace Monobehavior.Personajes
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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            Vector3 move = (transform.right * x + transform.forward * z).normalized * velMovimiento;
            rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
        }
    }
}