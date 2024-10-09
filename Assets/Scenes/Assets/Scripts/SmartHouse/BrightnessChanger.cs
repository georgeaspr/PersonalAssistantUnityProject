using UnityEngine;
using UnityEngine.UI;


public class BrightnessChanger : MonoBehaviour
{ 
    public Slider colorSlider;
    public Image image;

    public void changeColor()
    {
        float grayscaleIntensity = colorSlider.value;
        Color targetColor = Color.Lerp(new Color(100 / 255f, 100 / 255f, 100 / 255f), Color.white, grayscaleIntensity);
        image.color = targetColor;
    }
}
