using TMPro;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
using System.IO;


public class SwitchHandler : MonoBehaviour
{
    private int switchState = 1;
    public GameObject switchBtn;
    public TMP_Text location;
    private string fileName = "loc.txt";
    private string path;
    public GameObject weatherBlock;

    private void Start()
    {
        // Get the path to the persistent data directory
        path = Path.Combine(Application.persistentDataPath, fileName);


        if (!File.Exists(path))
        {
            File.WriteAllText(path, "0");
        }

    }


    public void OnSwitchButtonClicked()
    {
        switchBtn.transform.DOLocalMoveX(-switchBtn.transform.localPosition.x, 0.2f);
        switchState = Math.Sign(-switchBtn.transform.localPosition.x);
        Debug.Log(switchState);
    }

    public void changeONOFFText()
    {
        Image switchBackgroundImage = GameObject.Find("SwitchBackground")?.GetComponent<Image>();
        if (switchState == 1)
        {
            Color newColor;
            if (ColorUtility.TryParseHtmlString("#5ECA73", out newColor))
            {
                switchBackgroundImage.color = newColor;
                location.gameObject.SetActive(true);
                File.WriteAllText(path, "1");
            }
        }
        else
        {
            Color newColor;
            if (ColorUtility.TryParseHtmlString("#8C8C8C", out newColor))
            {
                switchBackgroundImage.color = newColor;
                location.gameObject.SetActive(false);
                File.WriteAllText(path, "0");
            }
        }
        checkStatus();
    }

    private void checkStatus()
    {
        string content = File.ReadAllText(path);
        if (content == "0")
        {
            weatherBlock.SetActive(true);
        }
        else
        {
            weatherBlock.SetActive(false);
        }
    }
}