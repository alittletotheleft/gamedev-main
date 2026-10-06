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
    private Coroutine gameLoop = null;

    public void StartGame()
    {
        gameUI.SetActive(true);
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
}
