using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunSetup : MonoBehaviour
{
    public Image myImage;

    public Sprite Close, open;
    public Text myText;

    public bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        isOn = true;
        myImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeRun()
    {
        if (isOn)
        {
            myText.text = "Открыть полосу";
            myImage.sprite = Close;
        }
        else
        {
            myText.text = "Закрыть полосу";
            myImage.sprite = open;
        }
        isOn = !isOn;
    }
}
