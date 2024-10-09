using UnityEngine;
using UnityEngine.UI;

public class RadioScript : MonoBehaviour
{
    public Button ONOFF;
    public Slider slider;
    public Slider volume;
    public Text displayText;
    public float value = 88.0f;
    private bool ison = false;

    private void Start()
    {
        if (ison)
        {
            slider.interactable = true;
            volume.interactable = true;
            displayText.text = value.ToString("F1") + "MHz";
        }
        else
        {
            slider.interactable = false;
            volume.interactable = false;
            displayText.text = "OFF";
        }
    }

    public void Tune()
    {
        value = slider.value * 20 + 88;
        displayText.text = value.ToString("F1") + "MHz";
    }

    public void ONOFFRadio()
    {
        if (ison)
        {
            slider.interactable = false;
            volume.interactable = false;
            ison = false;
            displayText.text = "OFF";
        }
        else
        {
            slider.interactable = true;
            volume.interactable = true;
            ison = true;
            displayText.text = value.ToString("F1") + "MHz";
        }
    }

}
