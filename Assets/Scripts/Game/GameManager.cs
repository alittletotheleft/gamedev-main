using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private LaserSpawner laserSpawner;
    [SerializeField] private float duration = 30f;
    private Coroutine gameLoop;

    private void Start()
    {
        gameState.IsGameRunning = false;
        
        StartGame();
    } 

    private void StartGame()
    {
        if (gameState.IsGameRunning)
            return;
        
        laserSpawner.StartSpawning();
        gameLoop = StartCoroutine(GameLoop());
        gameState.IsGameRunning = true;
    }

    private void StopGame()
    {
        if (!gameState.IsGameRunning)
            return;

        laserSpawner.StopSpawning();
        StopCoroutine(gameLoop);
        gameState.IsGameRunning = false;
    }

    private IEnumerator GameLoop()
    {
        yield return new WaitForSeconds(duration);
    }

    public void OnPlayerDeath()
    {
        Debug.Log("Player died");
        StopGame();
    }

    public void OnPlayerGoal()
    {
        Debug.Log("Player won");
        StopGame();
    }
}
