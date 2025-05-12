using UnityEngine;

public class ScoreAdd : MonoBehaviour
{
    private bool scored = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!scored && other.CompareTag("Player"))
        {
            Object.FindFirstObjectByType<Score>().AddPoint();
            scored = true;
        }
    }
}
