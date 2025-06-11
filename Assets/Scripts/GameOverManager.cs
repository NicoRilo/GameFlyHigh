using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Panel de Game Over

    //Metodo que se llama para mostrar el panel de Game Over
    public void ShowGameOver()
    {
        Time.timeScale = 0f; // Detener el tiempo del juego
        gameOverPanel.SetActive(true); 

        // Iniciar la corutina para subir el score después de obtener el maxScore
        StartCoroutine(UploadScoreAfterGettingMax());
    }

    // Corutina para subir el score después de obtener el maxScore del servidor
    // Solo lo sube si el score actual es mayor que el maxScore del servidor
    private IEnumerator UploadScoreAfterGettingMax()
    {
        // Obtener el score actual del jugador
        int currentScore = FindFirstObjectByType<Score>().score;
        // Obtener el nombre de usuario
        string username = PlayerPrefs.GetString("LoggedUser", "");

        // Obtener el nuevo maxScore del servidor
        ScoreUpload scoreUploader = FindFirstObjectByType<ScoreUpload>();
        yield return StartCoroutine(scoreUploader.GetMaxScore(username));

        // Leer el valor actualizado del servidor
        int maxScoreFromServer = PlayerPrefs.GetInt("MaxScoreFromServer", 0);

        int updatedMaxScore = Mathf.Max(currentScore, maxScoreFromServer);

        // Enviar score actual y maxScore actualizado
        scoreUploader.SendScoreToServer(currentScore, updatedMaxScore);
    }


    // Método para reiniciar el juego
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Método para volver a la pantalla de inicio
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

