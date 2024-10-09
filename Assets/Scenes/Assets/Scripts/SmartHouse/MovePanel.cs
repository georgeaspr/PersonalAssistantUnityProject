using UnityEngine;
using System.Collections;


public class MovePanel : MonoBehaviour
{
    public Transform panelToMove;
    public float moveDuration = 1f;
    public Vector3 targetLocalPosition = new Vector3(-628f, 0f, 0f);
    public GameObject background;

    private bool isMoving = false;
    private Vector3 initialLocalPosition;
    private Vector3 targetPosition;
    private float elapsedTime = 0f;

    private void Start()
    {
        initialLocalPosition = panelToMove.localPosition;
        targetPosition = panelToMove.parent.TransformPoint(targetLocalPosition);
    }

    private void Update()
    {
        if (isMoving)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);
            panelToMove.localPosition = Vector3.Lerp(initialLocalPosition, targetLocalPosition, t);

            if (t >= 1f)
            {
                isMoving = false;
                elapsedTime = 0f;
            }
        }
    }

    public void MovePanelObject()
    {
        panelToMove.gameObject.SetActive(true);
        background.SetActive(true);
        if (isMoving)
        {
            isMoving = false;
            targetLocalPosition = initialLocalPosition;
            initialLocalPosition = panelToMove.localPosition;
        }
        else
        {
            isMoving = true;
            initialLocalPosition = panelToMove.localPosition;
            targetLocalPosition = panelToMove.parent.InverseTransformPoint(targetPosition);
        }
    }

    public void MoveToInitialPosition()
    {
        if (panelToMove != null && panelToMove.gameObject.activeSelf)
        {
            isMoving = true;
            targetLocalPosition = initialLocalPosition;
            initialLocalPosition = panelToMove.localPosition;

            Debug.Log("Execute to background");
            background.SetActive(false);
            StartCoroutine(DisableObject());
        }           
    }

    private IEnumerator DisableObject()
    {
        Debug.Log("Executed");
        yield return new WaitForSeconds(0.1f);
        panelToMove.gameObject.SetActive(false);
    }
}
