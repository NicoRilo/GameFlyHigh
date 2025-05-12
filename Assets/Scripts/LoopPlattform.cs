using UnityEngine;

public class LoopPlattform : MonoBehaviour
{
    public float speed = 1f;
    public float limit = 6f;

    private Vector2 startPosistion;

    void Start()
    {
        startPosistion = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        float newX = startPosistion.x - Mathf.Repeat(Time.time * speed, limit);
        transform.position = new Vector2(newX, transform.position.y);
    }
}
