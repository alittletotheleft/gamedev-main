using System;
using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private ThirdPersonController thirdPersonController;
    [SerializeField] private GameState gameState;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private int baseMaxHealth = 100;
    [SerializeField] private float baseMoveSpeed = 4f;
    [SerializeField] private float baseSprintSpeed = 6.5f;
    [SerializeField] private UnityEvent playerDeath;
    private Coroutine healthRegen = null;

    private void Start()
    {
        // baseMoveSpeed = thirdPersonController.MoveSpeed;
        // baseSprintSpeed = thirdPersonController.SprintSpeed;

        playerStats.MaxHealth = baseMaxHealth;
        playerStats.Health = baseMaxHealth;
        playerStats.MoveSpeed = baseMoveSpeed;
        playerStats.SprintSpeed = baseSprintSpeed;

        Debug.Log($"Player health: {playerStats.Health}");
    }

    public void StartGame()
    {
        if (healthRegen != null)
        {
            StopCoroutine(healthRegen);
        }
        healthRegen = StartCoroutine(HealthRegen());
    }

    public void StopGame()
    {
        if (healthRegen != null)
        {
            StopCoroutine(healthRegen);
            healthRegen = null;
        }
    }

    private IEnumerator HealthRegen()
    {
        while (true)
        {
            yield return new WaitForSeconds(playerStats.HealthRegenCooldown);
            if (playerStats.Health < playerStats.MaxHealth)
            {
                playerStats.Health += playerStats.HealthRegen;
            }
            Debug.Log("Healed");
        }
    }

    public void TakeDamage(int damage)
    {
        if (!gameState.IsGameRunning)
        {
            return;
        }
        
        playerStats.Health -= damage;
        Debug.Log($"Player health: {playerStats.Health}");
        if (playerStats.Health <= 0)
        {
            playerDeath.Invoke();
        }
    }
}
