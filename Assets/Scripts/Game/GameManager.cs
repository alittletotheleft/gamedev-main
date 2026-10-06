using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    // [SerializeField] private LaserSpawner laserSpawner;
    // [SerializeField] private UIManager uIManager;
    [SerializeField] private UnityEvent GameStart;
    [SerializeField] private UnityEvent GameStop;

    private void Start()
    {
        gameState.IsGameRunning = false;

        StartGame();
    }

    private void StartGame()
    {
        if (gameState.IsGameRunning)
            return;

        // laserSpawner.StartGame();
        // uIManager.StartGame();
        GameStart.Invoke();
        gameState.IsGameRunning = true;
    }

    private void StopGame()
    {
        if (!gameState.IsGameRunning)
            return;

        // laserSpawner.StopGame();
        GameStop.Invoke();
        gameState.IsGameRunning = false;
    }

    public void OnPlayerDeath()
    {
        Debug.Log("Player died");
        StopGame();
        StartCoroutine(GameReset());
    }

    public void OnPlayerGoal()
    {
        Debug.Log("Player won");
        StopGame();
        StartCoroutine(GameReset());
    }

    private IEnumerator GameReset()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Main");
    }
}
