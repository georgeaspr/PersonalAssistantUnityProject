using UnityEngine;

public class DisableEnableObject : MonoBehaviour
{
    public GameObject tab;


    public void whenButtonClicked()
    {
        if (tab.activeInHierarchy == true)
        {
            tab.SetActive(false);
        }
        else
        {
            tab.SetActive(true);
        }
    }
}
