using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NewMonoBehaviour : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;
    public Button loginButton;
    public Text resultText;

    public string loginUrl = "https://codev.com/login";

    // Use this for initialization
    public void Start()
    {
        loginButton.onClick.AddListener(OnLoginButtonClicked);


    }

    public void OnLoginButtonClicked()
    {
        string username = usernameField.text;
        string password = passwordField.text;

        StartCoroutine(Login(username, password));
    }

    IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post(loginUrl, form);

        yield return www.SendWebRequest();

        if(www.result == UnityWebRequest.Result.ConnectionError ||
            www.result == UnityWebRequest.Result.ProtocolError)
        {
            resultText.text = "Error: " + www.error;
        }
        else
        {
            var response = JsonUtility.FromJson<LoginResponse>(www.downloadHandler.text);

            if(response.success)
            {
                resultText.text = "Login successful!";
            }
            else
            {
                resultText.text = "Login failed: " + response.message;
            }
        }

    }

    public class LoginResponse
    {
        public bool success;
        public string message;
    }

}
