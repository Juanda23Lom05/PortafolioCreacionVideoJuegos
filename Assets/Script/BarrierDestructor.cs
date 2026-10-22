using UnityEngine;
using UnityEngine.SceneManagement;

public class BarrierAutoForward : MonoBehaviour
{
    [Header("Configuración de la Barrera")]
    [SerializeField] private float moveSpeed = 4f;                 
    [SerializeField] private string obstacleTag = "Obstaculo";     

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(obstacleTag))
        {
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}