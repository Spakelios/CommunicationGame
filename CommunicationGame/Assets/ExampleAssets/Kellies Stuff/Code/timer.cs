using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class timer : MonoBehaviour
{
    public GameObject image;
    float currentTime = 0f;
    float startingTime = 30f;

    public TextMeshProUGUI countdownText;
   
    void Start()
    {
        currentTime = startingTime;
    }
    
    void Update()
    {
        currentTime -= 1 * Time.deltaTime; // decreases by once per secound
        countdownText.text = currentTime.ToString("F1");

        if (currentTime <= 0)
        {
            image.SetActive(true);
        }
    }
}