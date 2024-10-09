using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DropDownMainMenuPosition : MonoBehaviour
{
    public GameObject mainmenu;
    private string fileName = "mainmenupos.txt";
    private string choice;
    private string path;
    public GameObject dropdownObject;
    private Dropdown dropdownComponent;

    private void Start()
    {
        // Get the path to the persistent data directory
        path = Path.Combine(Application.persistentDataPath, fileName);

        //Get DropDown Component from dropdownObject
        dropdownComponent = dropdownObject.GetComponent<Dropdown>();

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "center");
        }
        else
        {
            string content = File.ReadAllText(path);
            if ((content != "center") && (content != "top") && (content != "right") && (content != "left") && (content != "bottom"))
            {
                File.WriteAllText(path, "center");
            }
        }
        changePos();
    }

    public void dropdownChoices(int index)
    {
        switch (index)
        {
            case 0:
                File.WriteAllText(path, "center");
                break;
            case 1:
                File.WriteAllText(path, "top");
                break;
            case 2:
                File.WriteAllText(path, "bottom");
                break;
            case 3:
                File.WriteAllText(path, "right");
                break;
            case 4:
                File.WriteAllText(path, "left");
                break;
        }
        changePos();
    }


    private void changePos()
    {
        Debug.Log("ETREXA");
        choice = File.ReadAllText(path);
        RectTransform rectTransform = mainmenu.GetComponent<RectTransform>();

        if (choice == "center")
        {
            rectTransform.anchoredPosition = new Vector2(0, 0);
            dropdownComponent.value = 0;
        }
        else if (choice == "top")
        {
            rectTransform.anchoredPosition = new Vector2(0, 195);
            dropdownComponent.value = 1;
        }
        else if (choice == "bottom")
        {
            rectTransform.anchoredPosition = new Vector2(0, -235);
            dropdownComponent.value = 2;
        }
        else if (choice == "right")
        {
            rectTransform.anchoredPosition = new Vector2(555, 0);
            dropdownComponent.value = 3;
        }
        else if (choice == "left")
        {
            rectTransform.anchoredPosition = new Vector2(-555, 0);
            dropdownComponent.value = 4;
        }
    }
}
