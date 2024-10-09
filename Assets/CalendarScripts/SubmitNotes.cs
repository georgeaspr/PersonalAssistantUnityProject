using UnityEngine;
using TMPro;
using System.IO;

public class SubmitNotes: MonoBehaviour
{
    public TMP_InputField notesInputField;
    public GameObject[] months;
    public int i;

    private string notesFolderPath;

    public void ChangeNote()
    {
        for (i = 0; i<12; i++)
        {
            if (months[i].activeSelf)
            {
                CalendarNotes.Notes[i, CalendarNotes.Day - 1] = notesInputField.text;

                notesFolderPath = Path.Combine(Application.persistentDataPath, "Calendar Notes");

                string fileName = months[i].name + " " + CalendarNotes.Day;
                string filePath = Path.Combine(notesFolderPath, fileName + ".txt");

                if (string.IsNullOrWhiteSpace(notesInputField.text))
                {
                    File.Delete(filePath);
                    CalendarNotes.Notes[i, CalendarNotes.Day - 1] = null;
                }
                else
                    File.WriteAllText(filePath, notesInputField.text);
            }
        }
    }
}
