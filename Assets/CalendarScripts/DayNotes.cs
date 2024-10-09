using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayNotes : MonoBehaviour
{
    public TMP_InputField notesInputField;
    public TextMeshProUGUI dayValue;
    public GameObject[] months;
    public int month;
    public string note;

    public void OnDayButtonClicked()
    {
        int day = int.Parse(dayValue.text);
        CalendarNotes.Day = day;
        for (int i = 0; i < 12; i++)
        {
            if (months[i].activeSelf)
                note = CalendarNotes.Notes[i, day - 1];
        }

        notesInputField.text = note;
    }
}
