using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFridge : MonoBehaviour
{
    public Animator anim;
    public bool P1inRange;
    public bool P2inRange;


    private void Awake()
    {
        P1inRange = false;
        P2inRange = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            P1inRange = true;
        }
        
        else if (other.CompareTag("Player2"))
        {
            P2inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            P1inRange = false;
        }
        
        else if (other.CompareTag("Player2"))
        {
            P2inRange = false;
        }
    }
}
