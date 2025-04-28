using UnityEngine;

public class MovePipe : MonoBehaviour
{
    private float movePipe = 0.65f;

    void Update()
    {
        transform.position += Vector3.left * movePipe * Time.deltaTime;
    }
}
