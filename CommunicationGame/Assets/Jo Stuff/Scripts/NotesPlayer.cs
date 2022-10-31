using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NotesPlayer : MonoBehaviour
{
    public PlayerInput playerInput;
    public Player2InputActions playerInputActions;
    private CharacterController playerController;
    public ReadNote readNote;
    public DialogueManager dialogueManager;

    public float speed = 5f;
    public Vector2 inputVector;
    private readonly Vector3 gravityVector = new Vector3(0, -9.81f, 0);
    public bool canMove;
    private void Awake()
    {
        canMove = true;
        dialogueManager = FindObjectOfType<DialogueManager>();
        playerController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new Player2InputActions();
        
        playerInputActions.Player.Enable();

    }

    public void Update()
    {
        ApplyGravity();
        if (canMove)
        {
            Movement();
        }

        if (readNote.inRange && !dialogueManager.readingNote && playerInputActions.Player.Interact.triggered)
        {
            readNote.TriggerDialogue();
        }
        
        else if (dialogueManager.readingNote && playerInputActions.Player.Interact.triggered)
        {
            dialogueManager.DisplayNextLine();
        }
    }

    public void Movement()
    {
        inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        //playerRB.AddForce(new Vector3(inputVector.x, 0,  inputVector.y) * speed, ForceMode.VelocityChange);
        playerController.Move(new Vector3(inputVector.x, 0, inputVector.y) * (speed * Time.deltaTime));
    }

    public void ApplyGravity()
    {
        playerController.Move(gravityVector);
    }
}
