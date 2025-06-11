using UnityEngine;

public class MovePipe : MonoBehaviour
{
    // Velocidad de movimiento del tubo
    private float movePipe = 0.65f;

    void Update()
    {
        // Mueve el objeto hacia la izquierda constantemente con el tiempo
        transform.position += Vector3.left * movePipe * Time.deltaTime;
    }
}
