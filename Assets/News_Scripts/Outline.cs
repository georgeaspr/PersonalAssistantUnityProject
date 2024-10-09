using UnityEngine;
using UnityEngine.UI;

public class Outline : MonoBehaviour
{
    public Toggle toggle;
    public Outline outline;

    private void Start()
    {
        // Subscribe to the OnValueChanged event of the toggle
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        // Enable or disable the outline based on the toggle value
        outline.enabled = isOn;
    }
}
