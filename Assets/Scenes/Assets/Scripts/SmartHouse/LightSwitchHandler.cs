using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;


public class LightSwitchHandler : MonoBehaviour
{
    private int switchState = -1;
    public GameObject switchBtn;
    public GameObject LightOFF;
    public GameObject LightON;
    public Slider interactableSlider;

    void Start()
    {
        LightOFF.SetActive(true);
        interactableSlider.interactable = false;
    }

    public void OnSwitchButtonClicked()
    {
        switchBtn.transform.DOLocalMoveX(-switchBtn.transform.localPosition.x, 0.2f);
        switchState = Math.Sign(-switchBtn.transform.localPosition.x);
        Debug.Log(switchState);
    }

    public void changeONOFFText()
    {
        Text ONOFF = GameObject.Find("ONOFF").GetComponent<Text>();
        Image switchBackgroundImage = GameObject.Find("SwitchBackground")?.GetComponent<Image>();
        if (switchState == 1)
        {
            ONOFF.text = "ON";
            Color newColor;
            if (ColorUtility.TryParseHtmlString("#5ECA73", out newColor))
            {
                switchBackgroundImage.color = newColor;
            }
            LightOFF.SetActive(false);
            LightON.SetActive(true);

            interactableSlider.interactable = true;

        }
        else
        {
            ONOFF.text = "OFF";
            Color newColor;
            if (ColorUtility.TryParseHtmlString("#8C8C8C", out newColor))
            {
                switchBackgroundImage.color = newColor;
            }
            LightON.SetActive(false);
            LightOFF.SetActive(true);

            interactableSlider.interactable = false;

        }
    }
}