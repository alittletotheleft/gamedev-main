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
    private Vector2 movement;
    private bool jump;
    private Vector3 velocity;

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
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

        velocity.x = Mathf.Lerp(velocity.x, movement.x * moveSpeed, moveSmoothing * Time.deltaTime);
        velocity.z = Mathf.Lerp(velocity.z, movement.y * moveSpeed, moveSmoothing * Time.deltaTime);

        // Vector3 finalMovement = new Vector3(movement.x, 0f, movement.y) * moveSpeed + Vector3.up * velocity.y;
        // character.Move(finalMovement * Time.deltaTime);
        character.Move(velocity * Time.deltaTime);
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
