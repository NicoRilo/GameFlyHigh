using UnityEngine;
using System.Collections;  // Necesario para las corutinas

public class FlyPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;
    private float tiltSpeed = 100;
    public GameOverManager gameOverManager;
    private bool canMove = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        StartCoroutine(WaitAndEnableMovement(1f));
    }

    IEnumerator WaitAndEnableMovement(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canMove = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void Update()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButton(0))
            {
                Jump();
            }

            tiltHead();
        }
    }

    void Jump()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void tiltHead()
    {
        float verticalVelocity = rb.linearVelocity.y;
        float tiltAngle = Mathf.Lerp(-65f, 65f, (verticalVelocity + 10f) / 20f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, tiltAngle), Time.deltaTime * tiltSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform") || collision.gameObject.CompareTag("pipe"))
        {
            FindFirstObjectByType<Score>().SaveMaxScore();
            gameOverManager.ShowGameOver();
        }
    }
}
