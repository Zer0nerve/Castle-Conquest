using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{

    private Rigidbody2D Player;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    [SerializeField] float runSpeed = 2f;

    private void Awake()
    {
        Player = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Movement.performed += Movement_performed;



    }

    private void Update()
    {
        
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        float speed = 1f;
        Player.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed * runSpeed, ForceMode2D.Force);
    }
    private void Movement_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        Vector2 inputVector = context.ReadValue<Vector2>();
        float speed = 1f;
        Player.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode2D.Force);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        { 
        Debug.Log("Jump!" + context.phase);
        Player.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);
    }
    }
}
