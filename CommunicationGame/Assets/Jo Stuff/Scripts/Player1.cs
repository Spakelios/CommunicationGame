using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.SpriteAssetUtilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerInputActions playerInputActions;
    private CharacterController playerController;
    public PickupIngredient pickupIngredient;
    public bool holdingItem;
    public ReadNote readNote;
    public DialogueManager dialogueManager;
    public bool canMove;
    public OpenDoor openDoor;
    public Bowl bowl;

    public float speed = 5f;
    public Vector2 inputVector;
    private readonly Vector3 gravityVector = new Vector3(0, -9.81f, 0);
    private void Awake()
    {
        canMove = true;
        holdingItem = false;
        pickupIngredient = null;
        openDoor = null;
        dialogueManager = FindObjectOfType<DialogueManager>();
        playerController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        bowl = GameObject.FindWithTag("P1Bowl").GetComponentInChildren<Bowl>();
        
        playerInputActions.Player.Enable();
        
        

    }

    public void Update()
    {
        ApplyGravity();

        if (canMove)
        {
            Movement();
        }

        if (readNote.P1inRange)
        {
            NoteCheck();
        }
    }

    public void LateUpdate()
    {
        if (pickupIngredient.P1inRange)
        {
            PickupCheck();
        }
    }

    
    public void FixedUpdate()
    {
                
        if (openDoor.P1inRange)
        {
            DoorCheck();
        }
    }
    

    public void Movement()
    {
        inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        //playerRB.AddForce(new Vector3(inputVector.x, 0,  inputVector.y) * speed, ForceMode.VelocityChange);
        playerController.Move(new Vector3(inputVector.x, 0, inputVector.y) * (speed * Time.deltaTime));
    }

    private void ApplyGravity()
    {
        playerController.Move(gravityVector);
    }
    
    private void PickupCheck()
    {
        switch (holdingItem)
        {
            case false when playerInputActions.Player.Interact.triggered:
                if (!pickupIngredient.inBowl)
                {
                    pickupIngredient.PickupP1();
                }
                break;
            case true when playerInputActions.Player.Interact.triggered:

                if (!bowl.P1inRange)
                {
                    pickupIngredient.PutDownP1();
                }
                
                else if (bowl.P1inRange)
                {
                    pickupIngredient.PutInBowlP1();
                }
                break;
        }
    }

    private void NoteCheck()
    {
        switch (dialogueManager.readingNote)
        {
            case false when playerInputActions.Player.OpenDoors.triggered:
                readNote.TriggerDialogueP1();
                break;
            case true when playerInputActions.Player.OpenDoors.triggered:
                dialogueManager.DisplayNextLine();
                break;
        }
    }

    private void DoorCheck()
    {
        if (openDoor.P1inRange && !openDoor.doorOpen && openDoor.doorClosed && playerInputActions.Player.OpenDoors.triggered)
        {
            Debug.Log("Open Door");
            openDoor.OpenDoorP1();
        }

        else if (openDoor.doorOpen && !openDoor.doorClosed && playerInputActions.Player.OpenDoors.triggered)
        {
            Debug.Log("Close Door");
            openDoor.CloseDoorP1();
        }
    }
}
