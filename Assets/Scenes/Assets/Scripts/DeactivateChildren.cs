using UnityEngine;

public class DeactivateChildren : MonoBehaviour
{
    public GameObject targetParent;
    public GameObject targetChild;

    public void DeactivateAllChildren()
    {
        for (int i = 0; i < targetParent.transform.childCount; i++)
        {
            GameObject child = targetParent.transform.GetChild(i).gameObject;
            child.SetActive(false);
        }

        targetChild.SetActive(true);
    }
}
