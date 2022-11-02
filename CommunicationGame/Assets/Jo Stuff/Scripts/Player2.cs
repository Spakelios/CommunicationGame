using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2 : MonoBehaviour
{
    public PlayerInput playerInput;
    public Player2InputActions playerInputActions;
    private CharacterController playerController;
    public ReadNote readNote;
    public DialogueManager dialogueManager;
    public PickupIngredient pickupIngredient;
    public bool holdingItem;
    public OpenDoor openDoor;
    public Bowl bowl;

    public float speed = 5f;
    public Vector2 inputVector;
    private readonly Vector3 gravityVector = new Vector3(0, -9.81f, 0);
    public bool canMove;
    private void Awake()
    {
        canMove = true;
        holdingItem = false;
        pickupIngredient = null;
        openDoor = null;
        dialogueManager = FindObjectOfType<DialogueManager>();
        playerController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new Player2InputActions();
        bowl = GameObject.FindWithTag("P2Bowl").GetComponentInChildren<Bowl>();

        playerInputActions.Player.Enable();

    }

    public void Update()
    {
        ApplyGravity();
        if (canMove)
        {
            Movement();
        }

        if (readNote.P2inRange)
        {
            NoteCheck();
        }
    }

    public void LateUpdate()
    {
        if (pickupIngredient.P2inRange)
        {
            PickupCheck();
        }
    }
    
    public void FixedUpdate()
    {
                
        if (openDoor.P2inRange)
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
                    pickupIngredient.PickupP2();
                }
                break;
            case true when playerInputActions.Player.Interact.triggered:
                if (!bowl.P2inRange)
                {
                    pickupIngredient.PutDownP2();
                }
                
                else if (bowl.P2inRange)
                {
                    pickupIngredient.PutInBowlP2();
                }
                break;
        }
    }

    private void NoteCheck()
    {
        switch (dialogueManager.readingNote)
        {
            case false when playerInputActions.Player.OpenDoors.triggered:
                readNote.TriggerDialogueP2();
                break;
            case true when playerInputActions.Player.OpenDoors.triggered:
                dialogueManager.DisplayNextLine();
                break;
        }
    }
    
    private void DoorCheck()
    {
        if (!openDoor.doorOpen && openDoor.doorClosed && playerInputActions.Player.OpenDoors.triggered)
        {
            Debug.Log("Open Door");
            openDoor.OpenDoorP2();
        }

        else if (openDoor.doorOpen && !openDoor.doorClosed && playerInputActions.Player.OpenDoors.triggered)
        {
            Debug.Log("Close Door");
            openDoor.CloseDoorP2();
        }
    }
}
