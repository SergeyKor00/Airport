using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionButton : MonoBehaviour
{

    public EnginerData data;

    private Image myImage;

    private GameObject myText;

    private bool IsActive;

    public int regionId;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Click);
        myText = transform.GetChild(0).gameObject;
        myImage = GetComponent<Image>();
    }


    private void Click()
    {
        if(IsActive)
            Disable();
        else
        {
            data.ShowRegion(this);
            myImage.color = Color.white;
            myText.SetActive(true);
            
            IsActive = true;
        }

        
        
    }

    public void Disable()
    {
        IsActive = false;
        myImage.color = Color.clear;
        myText.SetActive(false);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
