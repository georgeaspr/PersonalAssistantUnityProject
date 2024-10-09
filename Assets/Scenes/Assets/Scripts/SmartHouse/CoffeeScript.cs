using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeScript : MonoBehaviour
{

    public Button Big;
    public Button Normal;
    public Button Small;
    public Text S;
    public Text T;
    public Button Cold;
    public Button Hot;
    public Button Make;
    private bool SB = false;
    private bool TB = false;
    public GameObject readyPanel;
    private float elapsedTime = 0f;
    private float targetTime;
    public Text Timer;
    private Coroutine timerCoroutine;
    public Text readyText;
    public Button OKBtn;

    void Start()
    {
        checkBools();
    }
    public void chooseBigSize()
    {
        Normal.interactable = true;
        Small.interactable = true;
        Big.interactable = false;

        targetTime = 120.00f;
        S.text = "Big";
        SB = true;
        checkBools();
    }

    public void chooseNormalSize()
    {
        Normal.interactable = false;
        Small.interactable = true;
        Big.interactable = true;

        targetTime = 90.00f;
        S.text = "Normal";
        SB = true;
        checkBools();
    }

    public void chooseSmallSize()
    {
        Normal.interactable = true;
        Small.interactable = false;
        Big.interactable = true;

        targetTime = 60.00f;
        S.text = "Small";
        SB = true;
        checkBools();
    }

    public void chooseCold()
    {
        Cold.interactable = false;
        Hot.interactable = true;

        T.text = "Cold";
        TB = true;
        checkBools();
    }

    public void chooseHot()
    {
        Cold.interactable = true;
        Hot.interactable = false;

        T.text = "Hot";
        TB = true;
        checkBools();
    }


    private void checkBools()
    {
        if (SB && TB)
        {
            Make.interactable = true;
        }
        else
        {
            Make.interactable = false;
        }
    }

    public void makeCoffee()
    {
        readyText.text = "Your coffee will be ready at";
        readyPanel.SetActive(true);
        OKBtn.gameObject.SetActive(false);

        Normal.interactable = true;
        Small.interactable = true;
        Big.interactable = true;

        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(TimeCount());
    }



    private IEnumerator TimeCount()
    {
        while (elapsedTime < targetTime)
        {
            elapsedTime += Time.deltaTime;

            Timer.text = (targetTime - elapsedTime).ToString("0") +"s";
            
            if (targetTime - elapsedTime <= 0)
            {
                Timer.text = "Your coffee is ready.";
                readyText.text = "";
                OKBtn.gameObject.SetActive(true);
            }
            Debug.Log(elapsedTime);
            yield return null;
        }

        // Perform your desired actions here
        Debug.Log("Two minutes have passed!");

        // Reset the timer if needed
        elapsedTime = 0f;
    }
}
