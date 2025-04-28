using UnityEngine;

public class FlyPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;
    private float tiltSpeed = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButton(0))
        {
            Jump();
        }

        tiltHead();
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


}
