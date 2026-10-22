using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar la escena

public class LevelTrigger : MonoBehaviour
{
    [Header("Configuración de Etiquetas")]
    [SerializeField] private string obstacleTag = "Obstaculo"; // Para perder/morir
    [SerializeField] private string winTag = "Meta";          // Para ganar/reiniciar el nivel

    // Si choca físicamente (Colisiones normales con paredes u obstáculos)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(obstacleTag))
        {
            ReiniciarNivel();
        }
    }

    // Si atraviesa un objeto configurado como "Is Trigger" (como una zona de muerte o una meta)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(obstacleTag) || collision.CompareTag(winTag))
        {
            ReiniciarNivel();
        }
    }

    private void ReiniciarNivel()
    {
        // Opcional: Si quieres destruir la pelota al tocarlo
        // Destroy(gameObject);

        // Recarga la escena actual usando Unity 6 SceneManager
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}