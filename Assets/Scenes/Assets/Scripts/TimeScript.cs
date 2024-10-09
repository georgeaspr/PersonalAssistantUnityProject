using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeScript : MonoBehaviour
{
    public Text timeText;

    void Update()
    {
        TimeSpan currentTime = DateTime.Now.TimeOfDay;
        timeText.text = currentTime.ToString(@"hh\:mm\:ss");
    }
}
