using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechSelection : MonoBehaviour
{

    public Text myText;


    public int defValue;

    private int selectedCount;


    private void Start()
    {
        selectedCount = defValue;

    }
    public void AddValue(int value)
    {

        selectedCount += value;

        if (selectedCount < 0)
            selectedCount = 0;

        myText.text = selectedCount.ToString();
        
    }



}
