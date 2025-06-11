using UnityEngine;

public class ScoreAdd : MonoBehaviour
{
    // Variable para asegurarse de que solo se sume un punto una vez por colisión
    private bool scored = false;

    // Método que se activa cuando otro collider entra en el trigger de este objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica que aún no se haya sumado un punto y que el objeto que entra sea el jugador
        if (!scored && other.CompareTag("Player"))
        {
            // Busca el primer objeto de tipo Score y le suma un punto
            Object.FindFirstObjectByType<Score>().AddPoint();
            // Evitamos que se sume más de una vez
            scored = true;
        }
    }
}
