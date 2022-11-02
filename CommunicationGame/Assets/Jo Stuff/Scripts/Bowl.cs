using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{

    public Player1 player1;
    public Player2 player2;

    public bool P1inRange;
    public bool P2inRange;

    private void Awake()
    {
        player1 = FindObjectOfType<Player1>();
        player2 = FindObjectOfType<Player2>();
        P1inRange = false;
        P2inRange = false;
    }


    private void OnTriggerStay(Collider other)
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
