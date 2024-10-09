using UnityEngine;
using TMPro;

public class NotesDateManager : MonoBehaviour
{
    public TextMeshProUGUI day;
    public GameObject[] months;
    public string text;

    public void ChangeNotesDate()
    {
        foreach (GameObject m in months)
        {
            if (m.activeSelf)
            {
                text = m.name;
            }
        }
        day.text = text + ' ' + CalendarNotes.Day.ToString();
    }
}
