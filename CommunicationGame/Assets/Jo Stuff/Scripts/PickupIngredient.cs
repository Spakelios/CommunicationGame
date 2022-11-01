using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupIngredient : MonoBehaviour
{
    //public bool inRange;
    public GameObject ingredient;
    public GameObject hand1;
    public GameObject hand2;
    //public IngredientsPlayer player;

    public Player1 player1;
    public Player2 player2;
    public bool P1inRange;
    public bool P2inRange;

    private void Awake()
    {
        //player = FindObjectOfType<IngredientsPlayer>();

        player1 = FindObjectOfType<Player1>();
        player2 = FindObjectOfType<Player2>();
        //inRange = false;
        P1inRange = false;
        P2inRange = false;
        ingredient = gameObject.transform.parent.gameObject;
        hand1 = GameObject.Find("Hand1");
        hand2 = GameObject.Find("Hand2");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            P1inRange = true;
            player1.pickupIngredient = this;
        }
        
        else if (other.CompareTag("Player2"))
        {
            P2inRange = true;
            player2.pickupIngredient = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            P1inRange = false;
            player1.pickupIngredient = null;
        }
        
        else if (other.CompareTag("Player2"))
        {
            P2inRange = false;
            player2.pickupIngredient = null;
        }
    }

    public void PickupP1()
    {
        ingredient.GetComponent<Rigidbody>().isKinematic = true;
        ingredient.transform.position = hand1.transform.position;
        ingredient.transform.parent = hand1.transform;
        player1.holdingItem = true;
    }

    public void PutDownP1()
    {
        ingredient.GetComponent<Rigidbody>().isKinematic = false;
        ingredient.transform.parent = null;
        player1.holdingItem = false;
    }
    
    public void PickupP2()
    {
        ingredient.GetComponent<Rigidbody>().isKinematic = true;
        ingredient.transform.position = hand2.transform.position;
        ingredient.transform.parent = hand2.transform;
        player2.holdingItem = true;
    }

    public void PutDownP2()
    {
        ingredient.GetComponent<Rigidbody>().isKinematic = false;
        ingredient.transform.parent = null;
        player2.holdingItem = false;
    }
}
