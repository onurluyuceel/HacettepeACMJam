using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private string OBSTACLE_TAG = "Obstacle";
    private PlayerInputActions playerInputActions;
    private Rigidbody2D playerRigidbody2D;
    private bool isGrounded;
    private bool isSprinting;
    private bool isWalking;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float movingSpeed = 5f, sprintingMoveSpeed = 10f, walkingSpeed = 2f, moveSpeed;
    private void Awake()
    {
        isGrounded = true;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump_Performed;
        playerInputActions.Player.Sprint.performed += Start_Sprinting;
        playerInputActions.Player.Sprint.canceled += Stop_Sprinting;
        playerInputActions.Player.Walk.performed += Start_Walking;
        playerInputActions.Player.Walk.canceled += Stop_Walking;
    }

    private void Start_Sprinting(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isSprinting = true;
        }
    }

    private void Stop_Sprinting(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            isSprinting = false;
        }
    }

    private void Start_Walking(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isWalking = true;
        }
    }

    private void Stop_Walking(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            isWalking = false;
        }
    }
    private Vector3 GetMovementDirection()
    {
        float inputVector = playerInputActions.Player.Move.ReadValue<float>();
        Vector2 targetPosition = transform.position;
        Vector3 moveDir = new Vector3(inputVector, 0, 0).normalized;
        return moveDir;
    }

    private void Jump_Performed(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            playerRigidbody2D.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        Vector3 moveDir = GetMovementDirection();

        playerRigidbody2D.velocity = new Vector3(moveDir.x * moveSpeed, playerRigidbody2D.velocity.y);

        if (isSprinting && isGrounded) 
        {
            moveSpeed = sprintingMoveSpeed;
        }
        else if (!isSprinting && !isWalking)
        {
            moveSpeed = movingSpeed;
        }
        else if(isWalking && isGrounded)
        {
            moveSpeed = walkingSpeed;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(OBSTACLE_TAG))
        {
            isGrounded = true;
        }
    }
}
