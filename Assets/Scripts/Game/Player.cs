using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [Space]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform ballSpawn;
    [SerializeField] private Transform ballsParent;
    [SerializeField] private float force = 10f;

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed && gameState.IsGameRunning)
        {
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        // Debug.Log("I drink soda I eat pizza");
        // Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        // Debug.DrawRay(ray.origin, ray.direction, Color.red, 5f);

        // Create projectile
        GameObject newBall = Instantiate(ball, ballsParent);
        newBall.transform.position = ballSpawn.transform.position;
        Ball b = newBall.GetComponent<Ball>();

        Vector3 mouseInput = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new (mouseInput.x, mouseInput.y, 8.75f));
        Vector3 direction = mouseWorldPosition - ballSpawn.position;
        b.Fire(direction * force);
    }
}
