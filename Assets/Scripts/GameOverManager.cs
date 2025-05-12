using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        StartCoroutine(UploadScoreAfterGettingMax());
    }

    private IEnumerator UploadScoreAfterGettingMax()
    {
        int currentScore = FindFirstObjectByType<Score>().score;
        string username = PlayerPrefs.GetString("LoggedUser", "");

        // Obtener el nuevo maxScore del servidor
        ScoreUpload scoreUploader = FindFirstObjectByType<ScoreUpload>();
        yield return StartCoroutine(scoreUploader.GetMaxScore(username));

        // Leer el valor actualizado del servidor
        int maxScoreFromServer = PlayerPrefs.GetInt("MaxScoreFromServer", 0);

        // Enviar score actual y maxScore actualizado
        scoreUploader.SendScoreToServer(currentScore, maxScoreFromServer);
    }


    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

