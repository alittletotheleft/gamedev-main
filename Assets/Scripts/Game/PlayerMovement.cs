using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [Space]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float moveSmoothing = 3.5f;
    [SerializeField] private Vector2 clamp = new (-20f, 20f);
    private Vector2 movement;
    private Vector2 velocity;

    private void Update()
    {
        velocity.x = Mathf.Lerp(velocity.x, movement.x * moveSpeed, moveSmoothing * Time.deltaTime);
        transform.Translate(velocity * Time.deltaTime);

        // Clamp 'x' position
        Vector3 clamped = transform.position;
        clamped.x = Mathf.Clamp(clamped.x, clamp.x, clamp.y);
        transform.position = clamped;

        // Debug.Log($"Movement: {movement} | Velocity: {velocity}");
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (gameState.IsGameRunning)
        {
            movement = context.ReadValue<Vector2>();
        }
    }
}
