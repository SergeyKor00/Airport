using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var MainAlgorithm = new MainAlgorithm();
        MainAlgorithm.GetOperationList(1);
        foreach (var item in MainAlgorithm.GetOperationList(1))
        {
            Debug.Log(item);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
