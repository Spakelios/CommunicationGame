using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupIngredient : MonoBehaviour
{
    public bool inRange;
    public GameObject ingredient;
    public GameObject hand;
    public A player;

    private void Awake()
    {
        player = FindObjectOfType<A>();
        inRange = false;
        ingredient = gameObject.transform.parent.gameObject;
        hand = GameObject.Find("Hand");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            player.pickupIngredient = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        player.pickupIngredient = null;
    }

    public void Pickup()
    {
        ingredient.GetComponent<Rigidbody>().isKinematic = true;
        ingredient.transform.position = hand.transform.position;
        ingredient.transform.parent = hand.transform;
        player.holdingItem = true;
    }

    public void PutDown()
    {
        ingredient.GetComponent<Rigidbody>().isKinematic = false;
        ingredient.transform.parent = null;
        player.holdingItem = false;
    }
}
