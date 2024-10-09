using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmScript : MonoBehaviour
{
    public Button OFF;
    public Button ON;
    public GameObject AlarmOn;
    public GameObject AlarmOff;

    void Start()
    {
        AlarmOff.SetActive(true);
        AlarmOn.SetActive(false);
    }

    
    public void OnBtn()
    {
        AlarmOff.SetActive(false);
        AlarmOn.SetActive(true);
    }

    public void OffBtn()
    {
        AlarmOff.SetActive(true);
        AlarmOn.SetActive(false);
    }
}
