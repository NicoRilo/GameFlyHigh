using UnityEngine;
using TMPro;
using System.Collections;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI maxScoreText;
    public int score = 0;
    private int maxScore = 0;

    // Coroutine que se ejecuta al iniciar el objeto
    IEnumerator Start()
    {
        // Si aún no se ha recibido el puntaje máximo del servidor, esperamos
        if (!PlayerPrefs.HasKey("MaxScoreFromServer"))
        {
            yield return null;
        }
        // Recuperamos el puntaje máximo guardado del servidor
        maxScore = PlayerPrefs.GetInt("MaxScoreFromServer", 0);
        // Actualizamos el texto del marcador
        UpdateScoreDisplay();
    }

    // Método para añadir un punto al marcador
    public void AddPoint()
    {
        score++;
        if (score > maxScore)
        {
            maxScore = score;
        }

        UpdateScoreDisplay();
    }

    // Guardamos el score máximo localmente
    public void SaveMaxScore()
    {
        PlayerPrefs.SetInt("MaxScore", maxScore);
        PlayerPrefs.Save();
    }

    // Actualiza en pantalla los textos del marcador y la puntuación máxima
    private void UpdateScoreDisplay()
    {
        scoreText.text = "SCORE: " + score.ToString();
        maxScoreText.text = "MAX SCORE: " + maxScore.ToString();
    }

    // Devuelve el valor actual de la puntuación máxima
    public int GetMaxScore()
    {
        return maxScore;
    }
}
