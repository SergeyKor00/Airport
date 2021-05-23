using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class MovingScript : MonoBehaviour
{
    public RectTransform myRect;


    public void MoveX(int value)
    {
        myRect.DOAnchorPosX(value, 1.0f);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
