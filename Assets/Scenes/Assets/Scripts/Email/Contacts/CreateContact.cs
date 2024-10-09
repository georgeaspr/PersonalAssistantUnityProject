using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class CreateContact : MonoBehaviour
{
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    public TMP_InputField inputField4;
    public Button button;
    public GameObject ErrorMessage;
    public GameObject CreatePanel;
    public GameObject CreateMessage;


    private int fileCounter = 1;
    private string emailFolderPath;
    private string contactsFolderPath;

    private void Start()
    {
        emailFolderPath = Path.Combine(Application.persistentDataPath, "Email");
        contactsFolderPath = Path.Combine(emailFolderPath, "Contacts");

        // Create the "Email" folder if it doesn't exist
        if (!Directory.Exists(emailFolderPath))
            Directory.CreateDirectory(emailFolderPath);

        // Create the "Contacts" folder if it doesn't exist
        if (!Directory.Exists(contactsFolderPath))
            Directory.CreateDirectory(contactsFolderPath);
        // Count the number of files already present in the "Contacts" folder
        string[] existingFiles = Directory.GetFiles(contactsFolderPath, "*.txt");
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
            string textToSave = $"{inputField1.text}\n{inputField2.text}\n{inputField3.text}\n{inputField4.text}";
            string fileName = "contact" + (fileCounter + 1).ToString() + ".txt";
            string filePath = Path.Combine(contactsFolderPath, fileName);

            // Check if the file already exists
            while (File.Exists(filePath))
            {
                fileCounter++;
                fileName = "contact" + fileCounter.ToString() + ".txt";
                filePath = Path.Combine(contactsFolderPath, fileName);
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
                inputField4.text = string.Empty;

                // Hide SendNewTab
                CreatePanel.SetActive(false);

                // Show Sent Message
                CreateMessage.SetActive(true);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error saving file: " + ex.Message);
            }

        }
    }
}
