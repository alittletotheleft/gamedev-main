using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private PlayerStats playerStats;
    [Space]
    [Header("Game UI")]
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameWinUI;
    [SerializeField] private TMP_Text healthBarLabel;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider boostBar;

    private Coroutine gameLoop = null;
    private Coroutine playerBoost = null;

    public void StartGame()
    {
        gameUI.SetActive(true);
        boostBar.gameObject.SetActive(false);
        if (gameLoop != null)
        {
            StopCoroutine(gameLoop);
        }
        gameLoop = StartCoroutine(GameLoop());
    }

    public void StopGame()
    {
        gameUI.SetActive(false);
        if (gameLoop != null)
        {
            StopCoroutine(gameLoop);
            gameLoop = null;
        }
    }

    public void OnPlayerBoost(float speedBoost, float duration)
    {
        if (playerBoost != null)
        {
            StopCoroutine(playerBoost);
        }
        playerBoost = StartCoroutine(PlayerBoost(duration));
    }

    private IEnumerator GameLoop()
    {
        while (true)
        {
            healthBar.maxValue = playerStats.MaxHealth;
            healthBar.value = playerStats.Health;
            healthBarLabel.SetText($"{playerStats.Health} / {playerStats.MaxHealth}");

            yield return null;
        }
    }

    private IEnumerator PlayerBoost(float duration)
    {
        boostBar.gameObject.SetActive(true);
        boostBar.maxValue = duration; 
        boostBar.value = boostBar.maxValue; 
        float time = 0f;

        while (time < duration)
        {
            boostBar.value = boostBar.maxValue - time;
            time += Time.deltaTime;
            yield return null;
        }

        boostBar.value = 0f;
        boostBar.gameObject.SetActive(false);
    }

    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }

    public void OnPlayerGoal()
    {
        gameWinUI.SetActive(true);
    }
}
