using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class InboxEmail : MonoBehaviour
{
    public GameObject buttonPrefab;
    public RectTransform buttonContainer;
    private string emailFolderPath;
    private string InboxFolderPath;
    private string filePath;

    private void Start()
    {
        Initialize();
        PopulateFileList();
    }

    private void Initialize()
    {
        emailFolderPath = Path.Combine(Application.persistentDataPath, "Email");
        InboxFolderPath = Path.Combine(emailFolderPath, "Inbox");

        // Create the "Email" folder if it doesn't exist
        if (!Directory.Exists(emailFolderPath))
            Directory.CreateDirectory(emailFolderPath);

        // Create the "Sent" folder if it doesn't exist
        if (!Directory.Exists(InboxFolderPath))
            Directory.CreateDirectory(InboxFolderPath);

        Debug.Log("buttonPrefab: " + buttonPrefab);
        Debug.Log("buttonContainer: " + buttonContainer);
    }

    private void PopulateFileList()
    {
        GameObject sampleButton = buttonContainer.transform.Find("InboxEmailButton").gameObject;

        // Clear existing buttons
        foreach (Transform child in buttonContainer)
        {
            if (child.gameObject != sampleButton)
            {
                Destroy(child.gameObject);
            }

        }

        if (sampleButton != null)
        {
            sampleButton.SetActive(true);
        }

        string[] files = Directory.GetFiles(InboxFolderPath);

        Debug.Log("Number of files: " + files.Length);

        for (int i = 0; i < files.Length; i++)
        {
            string file = files[i];
            Debug.Log("File path (" + i + "): " + file);

            try
            {
                GameObject button = Instantiate(buttonPrefab, buttonContainer);

                // Read the first two lines from the file
                string[] lines = File.ReadAllLines(file);
                if (lines.Length >= 1)
                {
                    Text firstLineText = button.transform.Find("From").GetComponent<Text>();
                    firstLineText.text = "From: " + TruncateText(lines[0], 15);
                }
                if (lines.Length >= 2)
                {
                    Text secondLineText = button.transform.Find("Subject").GetComponent<Text>();
                    secondLineText.text = "Subject: " + TruncateText(lines[1], 15);
                }

                // Set the file's date and time in the third Text component
                string fileDateTime = File.GetLastWriteTime(file).ToString();
                button.transform.Find("DateTime").GetComponent<Text>().text = "Date: " + fileDateTime;


                // Attach a script to each button to handle file opening and reading
                button.GetComponent<Button>().onClick.AddListener(() => OpenAndReadFile(file));

            }
            catch (System.Exception e)
            {
                Debug.LogError("Exception occurred while creating button: " + e.Message);
            }
        }
        // Deactivate the sample button

        if (sampleButton != null)
        {
            sampleButton.SetActive(false);
        }

    }

    private string TruncateText(string text, int maxLength)
    {
        if (text.Length > maxLength)
        {
            return text.Substring(0, maxLength - 3) + "...";
        }
        return text;
    }

    private void OpenAndReadFile(string filePath)
    {
        // Read the file contents
        string fileContents = File.ReadAllText(filePath);

        // Update File Path
        SetFilePath(filePath);

        // Do something with the file contents
        Debug.Log(fileContents);

        // Disable the RefreshButton
        GameObject refreshButton = GameObject.Find("RefreshButton");
        if (refreshButton != null)
        {
            Button button = refreshButton.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = false;
            }
        }
        // Enable the Back and Delete Button
        GameObject backButton = GameObject.Find("BackButton");
        GameObject deleteButton = GameObject.Find("DeleteButton");

        if (backButton != null)
        {
            Button button = backButton.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = true;
            }
        }

        if (deleteButton != null)
        {
            Button button = deleteButton.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = true;
            }
        }
        // Activate the ScrollReading object
        Transform parent = transform.parent.parent; // Get the grandparent transform
        GameObject scrollReading = parent.Find("ScrollReading").gameObject;
        if (scrollReading != null)
        {
            scrollReading.SetActive(true);
        }

        // Find the Text component within the ReadingPanel
        Text textComponent = scrollReading.GetComponentInChildren<Text>();
        if (textComponent != null)
        {
            // Assign the fileContents to the text component
            textComponent.text = fileContents;
        }

    }
    public void RefreshFileList()
    {
        // Repopulate the file list
        Initialize();
        PopulateFileList();
    }

    public void deleteFile()
    {
        try
        {
            // Delete the file
            File.Delete(filePath);
            Debug.Log("File deleted: " + filePath);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to delete file: " + filePath + ". Error: " + e.Message);
        }


    }


    public void SetFilePath(string path)
    {
        filePath = path;
        Debug.Log("New Path: " + filePath);
    }

}