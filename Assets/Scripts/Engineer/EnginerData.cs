using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnginerData : MonoBehaviour
{
    public Slider iceSlider, snowSlider;

    public Toggle ice, snow, weather;

    public Text comments, iceValue, snowValue;

    public int selectedId;

    void Update()
    {
        iceValue.text = $"Толщина слоя{iceSlider.value: 0.0} мм.";
        snowValue.text = $"Толщина слоя{snowSlider.value: 0.0} мм.";
    }


    public void Submit()
    {
        IRestAPI api = new RestManager();

        if (!snow.isOn)
            snowSlider.value = 0.0f;
        if (!ice.isOn)
            iceSlider.value = 0.0f;
        
        api.UpdateRegion(selectedId, snowSlider.value, iceSlider.value, comments.text);
        
        
    }
}
