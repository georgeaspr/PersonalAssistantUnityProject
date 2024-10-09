using UnityEngine;

public class DeactivateTabs : MonoBehaviour
{
    public GameObject targetParent;
    public GameObject targetChild;
    public GameObject menu;

    void Start()
    {
        for (int i = 0; i < targetParent.transform.childCount; i++)
        {
            GameObject child = targetParent.transform.GetChild(i).gameObject;
            child.SetActive(false);
        }
        menu.SetActive(true);
    }

    public void DeactivateAllTabs()
    {
        if (!targetChild.activeSelf)
        {
            menu.SetActive(false);
            for (int i = 0; i < targetParent.transform.childCount; i++)
            {
                GameObject child = targetParent.transform.GetChild(i).gameObject;
                child.SetActive(false);
            }

            targetChild.SetActive(true);
        }
        else
        {
            for (int i = 0; i < targetParent.transform.childCount; i++)
            {
                GameObject child = targetParent.transform.GetChild(i).gameObject;
                child.SetActive(false);
            }
            Debug.Log("eeeeeeeeeeeeeeeeee");
            menu.SetActive(true);
        }
    }
}
