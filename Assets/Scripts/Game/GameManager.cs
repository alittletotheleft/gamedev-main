using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LaserSpawner laserSpawner;
    [SerializeField] private float duration = 30f;
    private IEnumerator gameLoop;
    private bool isGameRunning;

    private void Awake()
    {
        gameLoop = GameLoop();
    }

    private void Start()
    {
        StartGame();
    } 

    private void StartGame()
    {
        laserSpawner.StartSpawning();
        StartCoroutine(gameLoop);
    }

    private IEnumerator GameLoop()
    {
        isGameRunning = true;
        
        yield return new WaitForSeconds(duration);

        isGameRunning = false;
    }
}
