using UnityEngine;

public class CloseLogoutPanel : MonoBehaviour
{
    public GameObject panel;

    void Update()
    {
        if (panel.activeSelf && Input.GetMouseButtonDown(0))
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition))
            {
                panel.SetActive(false);
            }
        }
    }
}
