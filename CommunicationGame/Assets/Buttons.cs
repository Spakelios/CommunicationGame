using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject text;
    public GameObject appear;
    public void button()
    {
        text.SetActive(false);
        appear.SetActive(true);
    }
    
    
}
