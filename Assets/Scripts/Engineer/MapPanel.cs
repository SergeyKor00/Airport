using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MapPanel : MonoBehaviour
{


    public float leftX, rightX, upY, downY;

    private RectTransform myTransform;

    private Vector2 prevPosition;

    public RectTransform mapTransform;

    public Image downPanel;

    public Text downText;

    private float waitingTime;

    private bool panelActive;

    public GameObject galleryButton;

    public Sprite openImage, closeImage;

   
    
    
 

    private void Start()
    {
        myTransform = transform as RectTransform;
        prevPosition = Vector2.zero;
    }


    public void OpenDownPanel(int id)
    {
       

    }
    private void Update()
    {
        
        // if (Input.touchCount > 0)
        // {
        //     var touch = Input.touches[0];
        //     if (touch.phase == TouchPhase.Began)
        //     {
        //         MoveMap(touch.position, true);
        //     }
        //     else if(touch.phase == TouchPhase.Moved)
        //     {
        //         MoveMap(touch.position, false);
        //     }
        // }

        if (Input.GetMouseButtonDown(0))
            MoveMap(Input.mousePosition, true);
        if (Input.GetMouseButton(0))
        {
            Vector2 pos = Input.mousePosition;
            MoveMap(pos, false);
        
        }

    }

    private void MoveMap(Vector2 pos, bool fistTouch)
    {
        Vector2 outVector;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myTransform, pos, null, out outVector);

        if (fistTouch)
            prevPosition = outVector;
        
        
        Vector3 newPos = mapTransform.localPosition + (Vector3)(outVector - prevPosition);
        
        if (newPos.x > leftX && newPos.x < rightX && newPos.y > downY && newPos.y < upY)
        {
            mapTransform.localPosition = newPos;
        }
        prevPosition = outVector;
    }


    
}
