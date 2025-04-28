using UnityEngine;

public class LoginRequestsDTO : MonoBehaviour
{
    public string username;
    public string password;

    public LoginRequestsDTO(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}
