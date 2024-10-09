using UnityEngine;
using UnityEngine.UI;
using System;

public class CalendarActiveMonth : MonoBehaviour
{
    public GameObject Jan;
    public GameObject Feb;
    public GameObject Mar;
    public GameObject Apr;
    public GameObject May;
    public GameObject Jun;
    public GameObject Jul;
    public GameObject Aug;
    public GameObject Sep;
    public GameObject Oct;
    public GameObject Nov;
    public GameObject Dec;

    public int currentMonth;

    void Start()
    {
        DateTime currentDate = DateTime.Now;
        currentMonth = currentDate.Month;

        switch (currentMonth)
        {
            case 1:
                Jan.SetActive(true);
                Feb.SetActive(false);
                Mar.SetActive(false);
                Apr.SetActive(false);
                May.SetActive(false);
                Jun.SetActive(false);
                Jul.SetActive(false);
                Aug.SetActive(false);
                Sep.SetActive(false);
                Oct.SetActive(false);
                Nov.SetActive(false);
                Dec.SetActive(false);
                break;
            case 2:
                Jan.SetActive(false);
                Feb.SetActive(true);
                Mar.SetActive(false);
                Apr.SetActive(false);
                May.SetActive(false);
                Jun.SetActive(false);
                Jul.SetActive(false);
                Aug.SetActive(false);
                Sep.SetActive(false);
                Oct.SetActive(false);
                Nov.SetActive(false);
                Dec.SetActive(false);
                break;
            case 3:
                Jan.SetActive(false);
                Feb.SetActive(false);
                Mar.SetActive(true);
                Apr.SetActive(false);
                May.SetActive(false);
                Jun.SetActive(false);
                Jul.SetActive(false);
                Aug.SetActive(false);
                Sep.SetActive(false);
                Oct.SetActive(false);
                Nov.SetActive(false);
                Dec.SetActive(false);
                break;
            case 4:
                Jan.SetActive(false);
                Feb.SetActive(false);
                Mar.SetActive(false);
                Apr.SetActive(true);
                May.SetActive(false);
                Jun.SetActive(false);
                Jul.SetActive(false);
                Aug.SetActive(false);
                Sep.SetActive(false);
                Oct.SetActive(false);
                Nov.SetActive(false);
                Dec.SetActive(false);
                break;
            case 5:
                Jan.SetActive(false);
                Feb.SetActive(false);
                Mar.SetActive(false);
                Apr.SetActive(false);
                May.SetActive(true);
                Jun.SetActive(false);
                Jul.SetActive(false);
                Aug.SetActive(false);
                Sep.SetActive(false);
                Oct.SetActive(false);
                Nov.SetActive(false);
                Dec.SetActive(false);
                break;
            case 6:
                Jan.SetActive(false);
                Feb.SetActive(false);
                Mar.SetActive(false);
                Apr.SetActive(false);
                May.SetActive(false);
                Jun.SetActive(true);
                Jul.SetActive(false);
                Aug.SetActive(false);
                Sep.SetActive(false);
                Oct.SetActive(false);
                Nov.SetActive(false);
                Dec.SetActive(false);
                break;
            case 7:
                Jan.SetActive(false);
                Feb.SetActive(false);
                Mar.SetActive(false);
                Apr.SetActive(false);
                May.SetActive(false);
                Jun.SetActive(false);
                Jul.SetActive(true);
                Aug.SetActive(false);
                Sep.SetActive(false);
                Oct.SetActive(false);
                Nov.SetActive(false);
                Dec.SetActive(false);
                break;
            case 8:
                Jan.SetActive(false);
                Feb.SetActive(false);
                Mar.SetActive(false);
                Apr.SetActive(false);
                May.SetActive(false);
                Jun.SetActive(false);
                Jul.SetActive(false);
                Aug.SetActive(true);
                Sep.SetActive(false);
                Oct.SetActive(false);
                Nov.SetActive(false);
                Dec.SetActive(false);
                break;
            case 9:
                Jan.SetActive(false);
                Feb.SetActive(false);
                Mar.SetActive(false);
                Apr.SetActive(false);
                May.SetActive(false);
                Jun.SetActive(false);
                Jul.SetActive(false);
                Aug.SetActive(false);
                Sep.SetActive(true);
                Oct.SetActive(false);
                Nov.SetActive(false);
                Dec.SetActive(false);
                break;
            case 10:
                Jan.SetActive(false);
                Feb.SetActive(false);
                Mar.SetActive(false);
                Apr.SetActive(false);
                May.SetActive(false);
                Jun.SetActive(false);
                Jul.SetActive(false);
                Aug.SetActive(false);
                Sep.SetActive(false);
                Oct.SetActive(true);
                Nov.SetActive(false);
                Dec.SetActive(false);
                break;
            case 11:
                Jan.SetActive(false);
                Feb.SetActive(false);
                Mar.SetActive(false);
                Apr.SetActive(false);
                May.SetActive(false);
                Jun.SetActive(false);
                Jul.SetActive(false);
                Aug.SetActive(false);
                Sep.SetActive(false);
                Oct.SetActive(false);
                Nov.SetActive(true);
                Dec.SetActive(false);
                break;
            case 12:
                Jan.SetActive(false);
                Feb.SetActive(false);
                Mar.SetActive(false);
                Apr.SetActive(false);
                May.SetActive(false);
                Jun.SetActive(false);
                Jul.SetActive(false);
                Aug.SetActive(false);
                Sep.SetActive(false);
                Oct.SetActive(false);
                Nov.SetActive(false);
                Dec.SetActive(true);
                break;
        }
    }

    void Update()
    {
        
    }

}
