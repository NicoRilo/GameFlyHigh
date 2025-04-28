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

    void OnLoginClick()
    {
        string user = name.text;
        string pass = password.text;
        StartCoroutine(LoginCoroutine(user, pass));
    }

    IEnumerator LoginCoroutine(string user, string pass)
    {
        LoginRequestsDTO loginRequest = new LoginRequestsDTO(user, pass);
        string jsonData = JsonUtility.ToJson(loginRequest);

        UnityWebRequest request = new UnityWebRequest("http://localhost:8080/proyecto/users/login", "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;

            if (responseText == "Login successful")
            {
                log.text = "Login realizado con éxito";
                yield return new WaitForSeconds(5f);
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

internal class LoginRequestDTO
{
}