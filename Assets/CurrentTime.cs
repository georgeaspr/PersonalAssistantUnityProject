using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CurrentTime : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text currentTime;

    // Update is called once per frame
    void Update()
    {
        currentTime.text = DateTime.Now.ToString();
    }
}
