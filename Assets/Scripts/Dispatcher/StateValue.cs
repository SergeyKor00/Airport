using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateValue : MonoBehaviour
{

    public Text myText;

    private DateTime startTime;

    public int lastCheckTime;


    // Start is called before the first frame update
    void Start()
    {

        startTime = DateTime.Now;

        myText = transform.GetChild(0).GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {

        myText.text = $"Время с последней проверки: {DateTime.Now.Minute - startTime.Minute + lastCheckTime} мин";

    }
}
