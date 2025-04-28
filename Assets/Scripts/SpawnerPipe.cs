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
        if (timer >= maxTime)
        {
            SpawnPipe();
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    void SpawnPipe()
    {
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + Random.Range(-hightRange, hightRange));
        GameObject pipeInstance = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);

        Destroy(pipeInstance, 5f);
    }
}
