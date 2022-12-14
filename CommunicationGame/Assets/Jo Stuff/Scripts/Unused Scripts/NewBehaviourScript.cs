using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerInputActions playerInputActions;
    private CharacterController playerController;

    public float speed = 5f;
    public Vector2 inputVector;
    private readonly Vector3 gravityVector = new Vector3(0, -9.81f, 0);
    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        
        playerInputActions.Player.Enable();

    }

    public void Update()
    {
        ApplyGravity();
        Movement();

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