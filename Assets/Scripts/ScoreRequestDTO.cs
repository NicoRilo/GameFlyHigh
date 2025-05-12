using UnityEngine;

public class ScoreRequestDTO
{
    public string username;
    public int score;
    public int maxScore;

    public ScoreRequestDTO(string username, int score, int maxScore)
    {
        this.username = username;
        this.score = score;
        this.maxScore = maxScore;
    }
}
