using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using TMPro;

public class PurchaseLoad : MonoBehaviour
{
    public GameObject buttonPrefab;
    public RectTransform buttonContainer;
    private string purchases;
    private string filePath;

    private void Start()
    {
        purchases = Path.Combine(Application.persistentDataPath, "Purchases");

        // Create the "Email" folder if it doesn't exist
        if (!Directory.Exists(purchases))
            Directory.CreateDirectory(purchases);


        Debug.Log("buttonPrefab: " + buttonPrefab);
        Debug.Log("buttonContainer: " + buttonContainer);


        PopulateFileList();
    }


    private void PopulateFileList()
    {
        GameObject sampleButton = buttonContainer.transform.Find("PurchaseButton").gameObject;

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


        string[] files = Directory.GetFiles(purchases);

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
                    Text firstLineText = button.transform.Find("PurchaseName").GetComponent<Text>();
                    firstLineText.text = TruncateText(lines[0], 25);
                }

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

        // Activate the CreatePurchasePanel object
        GameObject PurchasePanel = transform.parent.parent.Find("PurchasePanel")?.gameObject;
        if (PurchasePanel != null)
        {
            PurchasePanel.SetActive(true);
        }
        else
        {
            Debug.LogError("PurchasePanel object not found!");
            return;
        }

        // Create a StreamReader to read the file
        StreamReader reader = new StreamReader(filePath);

        // Read the first line and fill the NameInputField
        string firstLine = reader.ReadLine();
        TMP_InputField NameInputField = GameObject.Find("NameInputField").GetComponent<TMP_InputField>();
        if (NameInputField != null)
        {
            NameInputField.text = firstLine;
        }

        // Read the second line and fill the PhoneNumberInputField
        string secondLine = reader.ReadLine();
        TMP_InputField PhoneNumberInputField = GameObject.Find("PhoneNumberInputField").GetComponent<TMP_InputField>();
        if (PhoneNumberInputField != null)
        {
            PhoneNumberInputField.text = secondLine;
        }

        // Read the third line and fill the EmailInputField
        string thirdLine = reader.ReadLine();
        TMP_InputField EmailInputField = GameObject.Find("EmailInputField").GetComponent<TMP_InputField>();
        if (EmailInputField != null)
        {
            EmailInputField.text = thirdLine;
        }

        // Read the fourth line and fill the DescriptionInputField
        string fourthLine = reader.ReadLine();
        TMP_InputField DescriptionInputField = GameObject.Find("DescriptionInputField").GetComponent<TMP_InputField>();

        Debug.Log(fourthLine);
        
        if (string.IsNullOrWhiteSpace(fourthLine))
        {
            DescriptionInputField.text = "No description found.";
        }
        else
        {
            DescriptionInputField.text = fourthLine;
        }

        // Close the StreamReader
        reader.Close();


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


    }
    public void RefreshFileList()
    {
        // Repopulate the file list
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

    public void editPurchase()
    {
        try
        {
            // Get the parent object of the button
            GameObject parentObject = transform.parent.gameObject;

            // Find the PurchasePanel object among the siblings of the parent
            GameObject PurchasePanel = parentObject.transform.parent.Find("PurchasePanel").gameObject;

            // Find the objects among the children of the ContactPanel
            GameObject ErrorMessage = PurchasePanel.transform.Find("ErrorMessage").gameObject;
            GameObject SaveButton = PurchasePanel.transform.Find("SaveChangesButton").gameObject;
            GameObject CancelButton = PurchasePanel.transform.Find("CancelEdit").gameObject;
            Button BackButton = PurchasePanel.transform.Find("BackButton").GetComponent<Button>();
            Button DeleteButton = PurchasePanel.transform.Find("DeleteContactButton").GetComponent<Button>();

            TMP_InputField NameInputField = GameObject.Find("NameInputField").GetComponent<TMP_InputField>();
            TMP_InputField PhoneNumberInputField = GameObject.Find("PhoneNumberInputField").GetComponent<TMP_InputField>();
            TMP_InputField EmailInputField = GameObject.Find("EmailInputField").GetComponent<TMP_InputField>();
            TMP_InputField DescriptionInputField = GameObject.Find("DescriptionInputField").GetComponent<TMP_InputField>();

            // Check if any input fields are empty or whitespace-only
            if (string.IsNullOrWhiteSpace(NameInputField.text) || string.IsNullOrWhiteSpace(PhoneNumberInputField.text) || string.IsNullOrWhiteSpace(EmailInputField.text))
            {
                ErrorMessage.SetActive(true);
            }
            else
            {

                // Set file contents, name and and path  
                string textToSave = $"{NameInputField.text}\n{PhoneNumberInputField.text}\n{EmailInputField.text}\n{DescriptionInputField.text}";
                File.WriteAllText(filePath, textToSave);
                Debug.Log("File saved successfully at: " + filePath);

                //Deactivate Buttons
                ErrorMessage.SetActive(false);
                SaveButton.SetActive(false);
                CancelButton.SetActive(false);

                //Make Buttons Interactable
                BackButton.interactable = true;
                DeleteButton.interactable = true;

                //Make InputFields Non-Interactable
                NameInputField.interactable = false;
                PhoneNumberInputField.interactable = false;
                EmailInputField.interactable = false;
                DescriptionInputField.interactable = false;
            }
        }
        catch (Exception e)
        {
            Debug.Log("Input fields could not be found: " + e.Message);
        }

    }


    public void cancelEdit()
    {
        // Create a StreamReader to read the file
        StreamReader reader = new StreamReader(filePath);

        // Read the first line and fill the NameInputField
        string firstLine = reader.ReadLine();
        TMP_InputField NameInputField = GameObject.Find("NameInputField").GetComponent<TMP_InputField>();
        if (NameInputField != null)
        {
            NameInputField.text = firstLine;
        }

        // Read the second line and fill the PhoneNumberInputField
        string secondLine = reader.ReadLine();
        TMP_InputField PhoneNumberInputField = GameObject.Find("PhoneNumberInputField").GetComponent<TMP_InputField>();
        if (PhoneNumberInputField != null)
        {
            PhoneNumberInputField.text = secondLine;
        }
        
        // Read the third line and fill the EmailInputField
        string thirdLine = reader.ReadLine();
        TMP_InputField EmailInputField = GameObject.Find("EmailInputField").GetComponent<TMP_InputField>();
        if (EmailInputField != null)
        {
            EmailInputField.text = thirdLine;
        }

        // Read the fourth line and fill the DescriptionInputField
        string fourthLine = reader.ReadLine();
        TMP_InputField DescriptionInputField = GameObject.Find("DescriptionInputField").GetComponent<TMP_InputField>();

        Debug.Log(fourthLine);

        if (string.IsNullOrWhiteSpace(fourthLine))
        {
            DescriptionInputField.text = "No description found.";
        }
        else
        {
            DescriptionInputField.text = fourthLine;
        }

        // Close the StreamReader
        reader.Close();
    }

    public void SetFilePath(string path)
    {
        filePath = path;
        Debug.Log("New Path: " + filePath);
    }

}