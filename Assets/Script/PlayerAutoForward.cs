using UnityEngine;

public class PlayerAutoForward : MonoBehaviour
{
    [Header("Velocidades")]
    [SerializeField] private float forwardSpeed = 5f;  // Velocidad constante hacia adelante (Eje X)
    [SerializeField] private float verticalSpeed = 8f; // Velocidad de movimiento vertical (Eje Y)

    private Rigidbody2D rb;
    private float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Opcional: Asegura que empiece en la coordenada (0, 0)
        transform.position = new Vector2(0f, 0f);
    }

    void Update()
    {
        // Captura las teclas W/S o Flechas Arriba/Abajo
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // En Unity 6 usamos linearVelocity
        // X avanza de forma constante con la velocidad configurable, Y responde a tus teclas
        rb.linearVelocity = new Vector2(forwardSpeed, verticalInput * verticalSpeed);
    }
}