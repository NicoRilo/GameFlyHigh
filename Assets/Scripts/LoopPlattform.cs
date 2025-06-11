using UnityEngine;

public class LoopPlattform : MonoBehaviour
{
    public float speed = 1f;

    // Distancia máxima antes de reiniciar la posición
    public float limit = 6f;

    // Posición inicial para reiniciar el movimiento
    private Vector2 startPosistion;

    // Guardar la posición inicial al iniciar
    void Start()
    {
        startPosistion = new Vector2(transform.position.x, transform.position.y);
    }

    // Actualizar la posición del objeto en cada frame
    void Update()
    {
        float newX = startPosistion.x - Mathf.Repeat(Time.time * speed, limit);
        transform.position = new Vector2(newX, transform.position.y);
    }
}
