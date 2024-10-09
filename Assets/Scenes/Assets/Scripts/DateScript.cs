using UnityEngine;
using UnityEngine.UI;
using System;

public class DateScript : MonoBehaviour
{
    public Text dText;

    void Start()
    {
        string todayDate = System.DateTime.Today.ToString("yyyy-MM-dd");
        DateTime parsedDate = DateTime.ParseExact(todayDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        dText.text = parsedDate.ToString("dddd\ndd MMMM yyyy");
    }
}