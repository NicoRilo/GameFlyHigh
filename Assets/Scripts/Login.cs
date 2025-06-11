using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class Login : MonoBehaviour
{
    public TMP_InputField name;
    public TMP_InputField password;
    public Button loginButton;
    public TextMeshProUGUI log;

    void Start()
    {
        loginButton.onClick.AddListener(OnLoginClick);
    }

    // Método que se ejecuta al hacer click en el botón de login
    void OnLoginClick()
    {
        // Obtiene el nombre de usuario ingresado
        string user = name.text;
        // Obtiene la contraseña ingresada
        string pass = password.text;
        // Inicia la corrutina para realizar el login
        StartCoroutine(LoginCoroutine(user, pass));
    }

    // Corrutina que envía la solicitud de login al backend
    IEnumerator LoginCoroutine(string user, string pass)
    {
        // Verifica que el nombre de usuario y la contraseña no estén vacíos
        LoginRequestsDTO loginRequest = new LoginRequestsDTO(user, pass);
        // Convierte el objeto LoginRequestsDTO a JSON
        string jsonData = JsonUtility.ToJson(loginRequest);

        // Crea una solicitud HTTP POST para enviar los datos de login
        UnityWebRequest request = new UnityWebRequest("http://localhost:8080/proyecto/users/login", "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Envía la solicitud y espera la respuesta
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;

            if (responseText == "Login successful")
            {
                // Guarda el nombre del usuario localmente
                PlayerPrefs.SetString("LoggedUser", user);
                PlayerPrefs.Save();

                // Limpia cualquier MaxScore anterior en caché
                PlayerPrefs.DeleteKey("MaxScoreFromServer");

                // Llama a la función que obtiene el maxScore desde el servidor
                FindFirstObjectByType<ScoreUpload>().GetMaxScoreFromServer(user);

                // Mensaje de éxito
                log.text = "Login realizado con éxito";

                // Espera 2 segundos y luego cambia a la escena del juego
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene("Game");
            }
            else
            {
                log.text = "Usuario o contraseña incorrectos";
            }
        }
        else
        {
            log.text = $"Error de red: {request.error}";
        }
    }
}
