using System.Collections;
using System.Collections.Generic;
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

    public float speed = 5f;
    public Vector2 inputVector;
    private readonly Vector3 gravityVector = new Vector3(0, -9.81f, 0);
    private void Awake()
    {
        canMove = true;
        holdingItem = false;
        pickupIngredient = null;
        dialogueManager = FindObjectOfType<DialogueManager>();
        playerController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        
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
                pickupIngredient.PickupP1();
                break;
            case true when playerInputActions.Player.Interact.triggered:
                pickupIngredient.PutDownP1();
                break;
        }
    }

    private void NoteCheck()
    {
        switch (dialogueManager.readingNote)
        {
            case false when playerInputActions.Player.Interact.triggered:
                readNote.TriggerDialogueP1();
                break;
            case true when playerInputActions.Player.Interact.triggered:
                dialogueManager.DisplayNextLine();
                break;
        }
    }
}
