using UnityEngine;
using UnityEngine.UI;
using System;

public class CalendarDate: MonoBehaviour
{
    public Text d;

    void Start()
    {
        string todayDate = System.DateTime.Today.ToString("yyyy-MM-dd");
        DateTime parsedDate = DateTime.ParseExact(todayDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        d.text = parsedDate.ToString("dd MMMM yyyy");
    }
}