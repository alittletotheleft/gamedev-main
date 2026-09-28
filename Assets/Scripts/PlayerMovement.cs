using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float moveSmoothing = 3.5f;
    [SerializeField]
    private float jumpHeight = 1.5f;
    [SerializeField]
    private float gravity = -9.81f;
    private CharacterController character;
    private CapsuleCollider platformTrigger;
    private Vector2 movement;
    private bool jump;
    private Vector3 velocity;
    private Vector3 originalPosition;

    private void Start()
    {
        character = GetComponent<CharacterController>();
        platformTrigger = GetComponent<CapsuleCollider>();
        originalPosition = transform.position;
        Reset();
    }

    private void Update()
    {
        // Jumping
        if (character.isGrounded)
        {
            if (velocity.y < -2f)
            {
                velocity.y = -2f;
            }
            
            if (jump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        velocity.y += gravity * Time.deltaTime;

        // Horizontal movement + linear smoothing
        velocity.x = Mathf.Lerp(velocity.x, movement.x * moveSpeed, moveSmoothing * Time.deltaTime);
        velocity.z = Mathf.Lerp(velocity.z, movement.y * moveSpeed, moveSmoothing * Time.deltaTime);

        character.Move(velocity * Time.deltaTime);
    }

    public void Reset()
    {
        // Feels like a cheat...
        character.enabled = false;
        velocity = Vector3.zero;
        transform.position = originalPosition;
        character.enabled = true;
    }

    public void SetSpawnpoint(Vector3 newPosition)
    {
        originalPosition = newPosition;
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        jump = context.performed;
    }
}
