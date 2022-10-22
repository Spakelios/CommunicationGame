using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOneControls : MonoBehaviour
{
    public PlayerInput playerInput;
    //private PlayerInputActions playerInputActions;
    public InputActionAsset inputAction;
    public CharacterController playerController;
    public InputActionMap player;
    public InputAction move;

    public float speed = 1f;
    public Vector2 inputVector;
    private readonly Vector3 gravityVector = new Vector3(0, -9.81f, 0);
    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        inputAction = playerInput.actions;
        player = inputAction.FindActionMap("Player");
        move = player.FindAction("Movement");
        
        player.Enable();
        move.Enable();

        //playerInputActions.Player.Enable();
        //playerInputActions.Player2.Enable();

    }

    public void Update()
    {
        ApplyGravity();
        Movement();

    }

    private void Movement()
    {
        //inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        inputVector = move.ReadValue<Vector2>();
        playerController.Move(new Vector3(inputVector.x, 0, inputVector.y) * (speed * Time.deltaTime));
    }

    private void ApplyGravity()
    {
        playerController.Move(gravityVector);
    }
}
