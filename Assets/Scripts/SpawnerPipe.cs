using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    private float maxTime = 1.5f;
    private float hightRange = 0.45f;
    public GameObject pipePrefab;
    private float timer;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        // Si el temporizador supera el tiempo máximo definido,
        // generamos una nueva tubería y reiniciamos el temporizador
        if (timer >= maxTime)
        {
            SpawnPipe();
            timer = 0f;
        }
        // Incrementamos el temporizador con el tiempo que ha pasado desde el último frame
        timer += Time.deltaTime;
    }

    // Método que instancia una nueva tubería en una posición con altura aleatoria
    void SpawnPipe()
    {
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + Random.Range(-hightRange, hightRange));
        GameObject pipeInstance = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);

        // Destruimos la tubería después de 5 segundos
        Destroy(pipeInstance, 5f);
    }
}
