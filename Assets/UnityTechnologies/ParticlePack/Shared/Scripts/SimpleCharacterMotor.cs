using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityTechnologies.ParticlePack
{
[RequireComponent(typeof(CharacterController))]
public class SimpleCharacterMotor : MonoBehaviour
{
    public CursorLockMode cursorLockMode = CursorLockMode.Locked;
    public bool cursorVisible = false;
    [Header("Movement")]
    public float walkSpeed = 2;
    public float runSpeed = 4;
    public float gravity = 9.8f;
    [Space]
    [Header("Look")]
    public Transform cameraPivot;
    public float lookSpeed = 45;
    public bool invertY = true;
    [Space]
    [Header("Smoothing")]
    public float movementAcceleration = 1;

    // Matches the sensitivity of the old Input Manager "Mouse X/Y" axes.
    const float k_MouseSensitivity = 0.1f;

    CharacterController controller;
    Vector3 movement, finalMovement;
    float speed;
    Quaternion targetRotation, targetPivotRotation;


    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = cursorLockMode;
        Cursor.visible = cursorVisible;
        targetRotation = targetPivotRotation = Quaternion.identity;
    }

    void Update()
    {
        UpdateTranslation();
        UpdateLookRotation();
    }

    void UpdateLookRotation()
    {
        var mouseDelta = Mouse.current != null ? Mouse.current.delta.ReadValue() * k_MouseSensitivity : Vector2.zero;
        var x = mouseDelta.y;
        var y = mouseDelta.x;

        x *= invertY ? -1 : 1;
        targetRotation = transform.localRotation * Quaternion.AngleAxis(y * lookSpeed * Time.deltaTime, Vector3.up);
        targetPivotRotation = cameraPivot.localRotation * Quaternion.AngleAxis(x * lookSpeed * Time.deltaTime, Vector3.right);

        transform.localRotation = targetRotation;
        cameraPivot.localRotation = targetPivotRotation;
    }

    void UpdateTranslation()
    {
        if (controller.isGrounded)
        {
            var move = ReadMoveInput();
            var run = Keyboard.current != null && Keyboard.current.leftShiftKey.isPressed;

            var translation = new Vector3(move.x, 0, move.y);
            speed = run ? runSpeed : walkSpeed;
            movement = transform.TransformDirection(translation * speed);
        }
        else
        {
            movement.y -= gravity * Time.deltaTime;
        }
        finalMovement = Vector3.Lerp(finalMovement, movement, Time.deltaTime * movementAcceleration);
        controller.Move(finalMovement * Time.deltaTime);
    }

    // WASD / arrow keys and the gamepad left stick, like the old "Horizontal" and "Vertical" axes.
    static Vector2 ReadMoveInput()
    {
        var move = Vector2.zero;
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) move.x -= 1;
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) move.x += 1;
            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) move.y -= 1;
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) move.y += 1;
        }
        if (Gamepad.current != null)
            move += Gamepad.current.leftStick.ReadValue();
        move.x = Mathf.Clamp(move.x, -1, 1);
        move.y = Mathf.Clamp(move.y, -1, 1);
        return move;
    }
}
}
