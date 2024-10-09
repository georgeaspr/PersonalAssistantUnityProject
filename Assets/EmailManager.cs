using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class EmailManager : MonoBehaviour
{
    private string fileName = "email.txt";
    public GameObject emailBlock;
    private string path;
    public TMP_Text activeEmail;


    void Start()
    {
        path = Path.Combine(Application.persistentDataPath, fileName);

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "0");
        }
        else
        {
            emailBlock.SetActive(true);
        }
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
            }
            else
            {
                emailBlock.SetActive(true);
            }
        }
    }
}
