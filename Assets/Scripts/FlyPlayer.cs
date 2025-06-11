using UnityEngine;
using System.Collections;  // Necesario para las corutinas

public class FlyPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce; // Fuerza del salto
    private float tiltSpeed = 100; // Velocidad de inclinación de la cabeza
    public GameOverManager gameOverManager; 
    private bool canMove = false;

    void Start()
    {
        // Asegurarse de que el GameOverManager esté asignado
        if (gameOverManager == null)
        {
            gameOverManager = FindAnyObjectByType<GameOverManager>();
        }

        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D del jugador
        rb.bodyType = RigidbodyType2D.Kinematic; // Sin fisica al inicio
        StartCoroutine(WaitAndEnableMovement(1f));  // Esperar 1 segundo antes de permitir el movimiento
    }

    // Coroutine para esperar un tiempo antes de permitir el movimiento
    IEnumerator WaitAndEnableMovement(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canMove = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void Update()
    {
        // Solo permitir el movimiento si canMove es verdadero
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButton(0))
            {
                Jump();
            }

            tiltHead();
        }
    }

    // Método para realizar el salto
    void Jump()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Método para inclinar al jugador según la velocidad vertical
    void tiltHead()
    {
        float verticalVelocity = rb.linearVelocity.y;
        float tiltAngle = Mathf.Lerp(-65f, 65f, (verticalVelocity + 10f) / 20f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, tiltAngle), Time.deltaTime * tiltSpeed);
    }

    // Método para manejar la colisión con plataformas o tuberías
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform") || collision.gameObject.CompareTag("pipe"))
        {
            FindFirstObjectByType<Score>().SaveMaxScore();
            gameOverManager.ShowGameOver();
        }
    }
}
