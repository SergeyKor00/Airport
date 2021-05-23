using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var MainAlgorithm = new MainAlgorithm();
        foreach (var item in MainAlgorithm.GetOperationList(1))
        {
            Debug.Log(item);
        }

        foreach (var item in MainAlgorithm.GetTechCountList(1, MainAlgorithm.GetOperationList(1)))
        {
            Debug.Log(item.type + " - " + item.count);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
