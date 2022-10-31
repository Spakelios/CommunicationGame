using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2Trigger : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cam2.SetActive(true);
            cam1.SetActive(false);
            
        }
    }
}
