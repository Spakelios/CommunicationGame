using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator anim;
    public bool P1inRange;
    public bool P2inRange;
    public Player1 player1;
    public Player2 player2;
    public bool doorOpen;
    public bool doorClosed;

    private void Awake()
    {
        doorOpen = false;
        doorClosed = true;
        anim = GetComponent<Animator>();
        anim.SetBool("Close", true);
        player1 = FindObjectOfType<Player1>();
        player2 = FindObjectOfType<Player2>();
        P1inRange = false;
        P2inRange = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            P1inRange = true;
            player1.openDoor = this;
        }
        
        else if (other.CompareTag("Player2"))
        {
            P2inRange = true;
            player2.openDoor = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            P1inRange = false;
            player1.openDoor = null;
        }
        
        else if (other.CompareTag("Player2"))
        {
            P2inRange = false;
            player2.openDoor = null;
        }
    }

    public void OpenDoorP1()
    {
        doorOpen = true;
        doorClosed = false;
        anim.SetBool("Open", true);
        anim.SetBool("Close", false);
    }

    public void CloseDoorP1()
    {
        doorOpen = false;
        doorClosed = true;
        anim.SetBool("Open", false);
        anim.SetBool("Close", true);
    }
    
    public void OpenDoorP2()
    {
        doorOpen = true;
        doorClosed = false;
        anim.SetBool("Open", true);
        anim.SetBool("Close", false);
    }

    public void CloseDoorP2()
    {
        doorOpen = false;
        doorClosed = true;
        anim.SetBool("Open", false);
        anim.SetBool("Close", true);
    }
}
