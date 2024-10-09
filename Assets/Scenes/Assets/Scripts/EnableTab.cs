using UnityEngine;

public class EnableTab : MonoBehaviour
{
    public GameObject tab;


    public void whenTabClicked()
    {
            tab.SetActive(true);
    }
}