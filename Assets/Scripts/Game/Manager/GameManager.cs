using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private GameState gameState;
    [Space]
    [SerializeField] private UnityEvent GameStart;
    [SerializeField] private UnityEvent GameStop;

    private void Start()
    {
        gameState.IsGameRunning = false;
        gameState.CurrentLevelID = -1;
        uIManager.Reset();

        // StartGame();
    }

    private void StartGame()
    {
        uIManager.StartGame();
        levelManager.StartGame();
        GameStart.Invoke();

        gameState.IsGameRunning = true;
    }

    // private void StopGame()
    // {
    //     GameStop.Invoke();
    //     gameState.IsGameRunning = false;
    // }

    public void OnLevelSelect(int id)
    {
        Debug.Log("I drink soda I eat pizza");
        gameState.CurrentLevelID = id;
        StartGame();
    }

    public void ReselectLevel(InputAction.CallbackContext context)
    {
        Debug.Log("Testtttt");
        if (context.performed && gameState.IsGameRunning)
        {
            Debug.Log("Raaatssssss");
            SceneManager.LoadScene("Main");
        }
    }
}
