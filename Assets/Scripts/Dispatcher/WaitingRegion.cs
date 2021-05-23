using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingRegion : MonoBehaviour
{


    DataRepository repository;

    public Text myText;

    public GameObject notification;


    public Image borderImage;

    public GameObject buttonState;

    public Text stateValue;


    // Start is called before the first frame update
    void Start()
    {


        repository = new DataRepository();

        StartCoroutine(waitForNotific());
    }



    private IEnumerator waitForNotific()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            var result = repository.SelectFromReg(1);

            if(result.snow > 0.0f)
            {
                myText.text = $"Снег {result.snow:0} мм.\n Лед {result.ice} мм";
                notification.SetActive(true);
                yield break;
            }

        }
    }


    public void SaveRegion()
    {
        buttonState.SetActive(true);
        stateValue.text = "Последная проверка: только что";

        borderImage.color = Color.green;
    }



    // Update is called once per frame
    void Update()
    {



    }
}
