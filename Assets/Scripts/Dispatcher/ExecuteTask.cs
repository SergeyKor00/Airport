using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteTask : MonoBehaviour
{


    public Text statusText;

    public Image endImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Execute()
    {
        StartCoroutine(WaitForTime());

    }
    private IEnumerator WaitForTime()
    {


        yield return new WaitForSeconds(2.0f);

        statusText.text = "Завершил работу";

        statusText.color = Color.red;

        endImage.gameObject.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
