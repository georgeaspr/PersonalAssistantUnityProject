using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class CheckInputFields : MonoBehaviour
{
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    public Button button;
    public GameObject ErrorMessage;
    public GameObject SendNewTab;
    public GameObject SentMessage;


    private int fileCounter = 1;
    private string emailFolderPath;
    private string sentFolderPath;

    private void Start()
    {
        emailFolderPath = Path.Combine(Application.persistentDataPath, "Email");
        sentFolderPath = Path.Combine(emailFolderPath, "Sent");

        // Create the "Email" folder if it doesn't exist
        if (!Directory.Exists(emailFolderPath))
            Directory.CreateDirectory(emailFolderPath);

        // Create the "Sent" folder if it doesn't exist
        if (!Directory.Exists(sentFolderPath))
            Directory.CreateDirectory(sentFolderPath);
        // Count the number of files already present in the "Sent" folder
        string[] existingFiles = Directory.GetFiles(sentFolderPath, "*.txt");
        fileCounter = existingFiles.Length;
    }

    public void CheckInput()
    {
        // Check if any input fields are empty or whitespace-only
        if (string.IsNullOrWhiteSpace(inputField1.text) || string.IsNullOrWhiteSpace(inputField2.text) || string.IsNullOrWhiteSpace(inputField3.text))
        {
            // Show error message
            ErrorMessage.SetActive(true);
        }
        else
        {
            // Hide error message
            ErrorMessage.SetActive(false);

            // Set file contents, name and and path  
            string textToSave = $"{inputField1.text}\n{inputField2.text}\n{inputField3.text}";
            string fileName = "email" + (fileCounter +1).ToString() + ".txt";
            string filePath = Path.Combine(sentFolderPath, fileName);

            // Check if the file already exists
            while (File.Exists(filePath))
            {
                fileCounter++;
                fileName = "email" + fileCounter.ToString() + ".txt";
                filePath = Path.Combine(sentFolderPath, fileName);
            }

            try
            {
                File.WriteAllText(filePath, textToSave);
                Debug.Log("File saved successfully at: " + filePath);
                fileCounter++;

                // Clear the input fields
                inputField1.text = string.Empty;
                inputField2.text = string.Empty;
                inputField3.text = string.Empty;

                // Hide SendNewTab
                SendNewTab.SetActive(false);

                // Show Sent Message
                SentMessage.SetActive(true);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error saving file: " + ex.Message);
            }
            
        }
    }
}
