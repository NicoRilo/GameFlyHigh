using UnityEngine;

// Esta clase representa la estructura de datos que se enviará al servidor
public class ScoreRequestDTO
{
    public string username;
    public int score;
    public int maxScore;

    // Constructor que inicializa los valores de la clase
    public ScoreRequestDTO(string username, int score, int maxScore)
    {
        this.username = username;
        this.score = score;
        this.maxScore = maxScore;
    }
}
