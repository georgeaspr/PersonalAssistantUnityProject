using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System.IO;

public class EnterButton : MonoBehaviour
{
    public TMP_Text notification1;
    public TMP_Text notification2;
    public TMP_InputField email;
    public TMP_InputField password;
    public TMP_Text activeEmail;
    public TMP_Text emailText;
    public GameObject logInPanel;
    public GameObject confirmPanel;
    public Button logIn;
    public Button logOut;
    private string fileName = "email.txt";
    private string path;
    public GameObject emailBlock;

    void Start()
    {
        notification1.gameObject.SetActive(false);
        notification2.gameObject.SetActive(false);
        path = Path.Combine(Application.persistentDataPath, fileName);

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "0");
        }
        else
        {
            emailBlock.SetActive(true);
        }
        checkIfLogged();
    }

    public void EnterCredentials()
    {
        if (string.IsNullOrEmpty(email.text) || string.IsNullOrEmpty(password.text))
        {
            notification1.gameObject.SetActive(true);
            notification2.gameObject.SetActive(false);
        }
        else
        {
            bool isValid = Regex.IsMatch(email.text, @"^[^\s@][^@\s]+@[^@\s]+\.[^@\s]+$");
            if (isValid)
            {
                notification1.gameObject.SetActive(false);
                notification2.gameObject.SetActive(false);

                activeEmail.text = email.text;
                File.WriteAllText(path, email.text);

                activeEmail.gameObject.SetActive(true);
                emailText.gameObject.SetActive(true);

                logInPanel.SetActive(false);
                logIn.gameObject.SetActive(false);
                logOut.gameObject.SetActive(true);
                checkIfLogged();
            }
            else
            {
                notification2.gameObject.SetActive(true);
                notification1.gameObject.SetActive(false);
            }
        }
    }

    public void confirmLogOut()
    {
        confirmPanel.SetActive(false);

        email.text = null;
        password.text = null;
        File.WriteAllText(path, "0");

        logIn.gameObject.SetActive(true);
        logOut.gameObject.SetActive(false);

        activeEmail.gameObject.SetActive(false);
        emailText.gameObject.SetActive(false);

        checkIfLogged();
    }

    public void checkIfLogged()
    {
        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);
            if (content != "0")
            {
                activeEmail.text = content;
                emailBlock.SetActive(false);

                //Set Fields
                activeEmail.gameObject.SetActive(true);
                emailText.gameObject.SetActive(true);

                //Set Buttons
                logIn.gameObject.SetActive(false);
                logOut.gameObject.SetActive(true);
            }
            else
            {
                emailBlock.SetActive(true);
            }
        }
    }
}