using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

public class CalendarNotes : MonoBehaviour
{
    public static int Day;
    public static string[,] Notes = new string[12,31];

    private string notesFolderPath;
    public List<string[]> monthsArray;

    private void Start()
    {
        notesFolderPath = Path.Combine(Application.persistentDataPath, "Calendar Notes");

        if (!Directory.Exists(notesFolderPath))
            Directory.CreateDirectory(notesFolderPath);

        monthsArray = new List<string[]>();
        string[] files = Directory.GetFiles(notesFolderPath, "*.txt");

        foreach (string file in files)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);
            string fileContents = File.ReadAllText(file);

            string[] fileNameParts = fileName.Split(' ');
            if (fileNameParts.Length == 2)
            {
                string month = fileNameParts[0];
                int day = Convert.ToInt32(fileNameParts[1]);

                switch(month)
                {
                    case "January":
                        Notes[0, day - 1] = fileContents;
                        break;
                    case "February":
                        Notes[1, day - 1] = fileContents;
                        break;
                    case "March":
                        Notes[2, day - 1] = fileContents;
                        break;
                    case "April":
                        Notes[3, day - 1] = fileContents;
                        break;
                    case "May":
                        Notes[4, day - 1] = fileContents;
                        break;
                    case "June":
                        Notes[5, day - 1] = fileContents;
                        break;
                    case "July":
                        Notes[6, day - 1] = fileContents;
                        break;
                    case "August":
                        Notes[7, day - 1] = fileContents;
                        break;
                    case "September":
                        Notes[8, day - 1] = fileContents;
                        break;
                    case "October":
                        Notes[9, day - 1] = fileContents;
                        break;
                    case "November":
                        Notes[10, day - 1] = fileContents;
                        break;
                    case "December":
                        Notes[11, day - 1] = fileContents;
                        break;
                }
            }
        }
    }
}
