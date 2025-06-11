using UnityEngine;

// Esta clase representa un DTO para las solicitudes de inicio de sesión.
public class LoginRequestsDTO : MonoBehaviour
{
    // Atributos que representan los datos necesarios para una solicitud de inicio de sesión.
    public string username;
    public string password;

    // Constructor que inicializa los atributos con los valores proporcionados.
    public LoginRequestsDTO(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}
