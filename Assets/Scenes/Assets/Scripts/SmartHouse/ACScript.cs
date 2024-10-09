using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ACScript : MonoBehaviour
{
    public Button ONOFF;
    public Button HeatUP;
    public Button HeatDOWN;
    public Text textField;
    private int temp = 16;
    private bool ison = false;
    public Button Cold;
    public Button Hot;
    private bool isCold = true;
    public Text HotColdText;


    private void Start()
    {
        if (ison)
        {
            textField.text = temp.ToString() + "°C";
            ColdBtn();
        }
        else
        {
            textField.text = "OFF";
            Cold.interactable = false;
            Hot.interactable = false;
        }

    }


    public void HeatUp()
    {
        if (temp >= 10 && temp < 32 && ison)
        {
            temp++;
            textField.text = temp.ToString() + "°C";
        }
    }

    public void HeatDown()
    {
        if (temp <= 32 && temp > 10 && ison)
        {
            temp--;
            textField.text = temp.ToString() + "°C";
        }
    }
    public void ONOFFBtn()
    {
        if (ison)
        {
            ison = false;
            textField.text = "OFF";
            Cold.interactable = false;
            Hot.interactable = false;
            HotColdText.text = "";
        }
        else
        {
            ison = true;
            textField.text = temp.ToString() + "°C";
            if (isCold)
            {
                ColdBtn();
            }
            else
            {
                HotBtn();
            }
        }
    }

    public void ColdBtn()
    {
        isCold = true;
        Cold.interactable = false;
        Hot.interactable = true;
        HotColdText.text = "Cold";
    }

    public void HotBtn()
    {
        isCold = false;
        Cold.interactable = true;
        Hot.interactable = false;
        HotColdText.text = "Hot";
    }
}
