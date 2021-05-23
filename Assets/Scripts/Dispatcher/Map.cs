using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public int selectedId;

    private RegionButton previewButton;

    // Start is called before the first frame update


    public void ShowRegion(RegionButton newRegion)
    {

        if (previewButton != null)
            previewButton.Disable();

        selectedId = newRegion.regionId;
        previewButton = newRegion;


    }
}
