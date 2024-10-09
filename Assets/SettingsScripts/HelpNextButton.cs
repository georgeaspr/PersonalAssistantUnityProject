using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpNextButton : MonoBehaviour
{
    private int i;
    public GameObject[] helppanels;
    public GameObject hpanel;

    void Start()
    {
        i = 1;
    }


    public void nextPanel()
    {
        Debug.Log(i);
        if (i > 7)
        {
            helppanels[7].SetActive(false);
            Debug.Log(i + " TELIKO");
            i = 0;
            hpanel.SetActive(false);
        }
        else if (i == 0) 
        {
            helppanels[i].SetActive(true);
            i++;
        }
        else
        {
            helppanels[i-1].SetActive(false);
            helppanels[i].SetActive(true);
            i++;
        }
    

    }
}
