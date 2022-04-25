using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarBehaviour : MonoBehaviour
{
    public Slider slider;
    public Color Low;
    public Color High;


    // Start is called before the first frame update
    public void setHealth(float health, float maxHealth)
    {
        
        slider.maxValue = maxHealth;
        slider.value = health;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);
    }
}
