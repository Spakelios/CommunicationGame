using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemTest: MonoBehaviour
{
    public PlayerInput playerInput;
    public InputActionAsset playerInputActions;
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
        playerInputActions = playerInput.actions;
        player = playerInputActions.FindActionMap("Player");
        move = player.FindAction("Movement");
        player.Enable();

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
        playerController.Move(new Vector3(move.ReadValue<Vector2>().x, 0, move.ReadValue<Vector2>().y) * (speed * Time.deltaTime));
    }

    private void ApplyGravity()
    {
        playerController.Move(gravityVector);
    }
    

}
