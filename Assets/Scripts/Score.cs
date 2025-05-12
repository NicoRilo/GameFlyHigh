using UnityEngine;
using TMPro;
using System.Collections;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI maxScoreText;
    public int score = 0;
    private int maxScore = 0;

    IEnumerator Start()
    {
        if (!PlayerPrefs.HasKey("MaxScoreFromServer")){
            yield return null;
        }

        maxScore = PlayerPrefs.GetInt("MaxScoreFromServer", 0);
        UpdateScoreDisplay();
    }


    public void AddPoint()
    {
        score++;
        if (score > maxScore)
        {
            maxScore = score;
        }

        UpdateScoreDisplay();
    }

    public void SaveMaxScore()
    {
        // Guardamos el score máximo
        PlayerPrefs.SetInt("MaxScore", maxScore);
        PlayerPrefs.Save();
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "SCORE: " + score.ToString();
        maxScoreText.text = "MAX SCORE: " + maxScore.ToString();
    }

    public int GetMaxScore()
    {
        return maxScore;
    }
}
