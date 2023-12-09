using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class Player : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip miuwClip;
    [SerializeField] private UnityEvent miuw;
    private string OBSTACLE_TAG = "Obstacle";
    private PlayerInputActions playerInputActions;
    private Rigidbody2D playerRigidbody2D;
    private bool isGrounded;
    private bool isSprinting;
    private bool isWalking;
    private float lastMiuwTime;
    private float miuwCooldown = 2f;
    private float jumpSpeed;
    private float movingSpeed;
    private float sprintingMoveSpeed;
    private float sneakingSpeed; 
    private float moveSpeed;
    [SerializeField] PlayerScriptableObject playerScriptableObject;
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
        playerInputActions.Player.Miuw.performed += Miuw_Performed;
    }

    private void Start() {
        jumpSpeed = playerScriptableObject.JumpSpeed;
        movingSpeed = playerScriptableObject.DefaultMovingSpeed;
        sprintingMoveSpeed = playerScriptableObject.SprintingSpeed;
        sneakingSpeed = playerScriptableObject.SneakingSpeed;
    }

    private void Miuw_Performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Miuwing();
        }

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
            moveSpeed = sneakingSpeed;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(OBSTACLE_TAG))
        {
            isGrounded = true;
        }
    }

    public void Miuwing()
    {
        if (Time.time - lastMiuwTime >= miuwCooldown)
        {
            audioSource.clip = miuwClip;
            audioSource.Play();
            lastMiuwTime = Time.time;
        }
    }
}
