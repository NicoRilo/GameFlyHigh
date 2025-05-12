using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ScoreUpload : MonoBehaviour
{
    // Método para obtener el maxScore del servidor
    public void GetMaxScoreFromServer(string username)
    {
        StartCoroutine(GetMaxScore(username));
    }

    // Coroutine para obtener el maxScore del servidor
    public IEnumerator GetMaxScore(string username)
    {
        string url = "http://localhost:8080/proyecto/scores/max/" + username;  // URL del endpoint

        UnityWebRequest request = UnityWebRequest.Get(url);  // Realizamos una solicitud GET

        yield return request.SendWebRequest();  // Esperamos la respuesta

        if (request.result == UnityWebRequest.Result.Success)
        {
            // Si la solicitud es exitosa, parseamos el puntaje máximo recibido
            int maxScore = int.Parse(request.downloadHandler.text);

            // Puedes guardar este maxScore en algún lado si lo necesitas en el futuro
            PlayerPrefs.SetInt("MaxScoreFromServer", maxScore);
            PlayerPrefs.Save();
        }
        else
        {
            // Si ocurre algún error
            Debug.LogError("Error al obtener el puntaje máximo desde el servidor: " + request.error);
        }
    }
    public void SendScoreToServer(int score, int maxScore)
    {
        string username = PlayerPrefs.GetString("LoggedUser", "");

        ScoreRequestDTO scoreRequest = new ScoreRequestDTO(username, score, maxScore);
        string jsonData = JsonUtility.ToJson(scoreRequest);
        StartCoroutine(PostScore(jsonData));
    }

    private IEnumerator PostScore(string jsonData)
    {
        UnityWebRequest request = new UnityWebRequest("http://localhost:8080/proyecto/scores/add", "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();
    }
}
