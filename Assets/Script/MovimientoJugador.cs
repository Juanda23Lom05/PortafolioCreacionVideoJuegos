using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 8f;

    private Rigidbody2D rb;
    private float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Esto coloca la pelota exactamente en las coordenadas (0, 0) al iniciar la escena
        transform.position = new Vector2(0f, 0f);
    }

    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0f, verticalInput * moveSpeed);
    }
}