using System;
using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private CinemachineCamera playerCameraFollow;
    [SerializeField] private GameState gameState;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private GameObject flashlight;
    [SerializeField] private int baseMaxHealth = 100;
    [SerializeField] private float baseMoveSpeed = 4f;
    [SerializeField] private float baseSprintSpeed = 6.5f;
    [SerializeField] private float fOVBoost = 16f;
    [SerializeField] private float fOVDuration = 0.5f;
    [SerializeField] private AnimationCurve fOVCurve;
    [SerializeField] private UnityEvent PlayerDeath;
    private float originalFOV;

    private Coroutine healthRegen = null;
    private Coroutine playerBoost = null;

    private void Start()
    {
        playerStats.MaxHealth = baseMaxHealth;
        playerStats.Health = baseMaxHealth;
        playerStats.MoveSpeed = baseMoveSpeed;
        playerStats.SprintSpeed = baseSprintSpeed;
        originalFOV = playerCameraFollow.Lens.FieldOfView;
        playerStats.IsFlashlightOn = false;
        flashlight.SetActive(false);

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

    private void Update()
    {
        if (playerStats.IsFlashlightOn)
        {
            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 100f, Color.red, 0.1f);
            // if (Physics.SphereCast(mainCamera.transform.position, mainCamera.transform.forward, 100f, flashlightMask))
            // {
                
            // }
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
        // Debug.Log($"Player health: {playerStats.Health}");
        if (playerStats.Health <= 0)
        {
            PlayerDeath.Invoke();
        }
    }

    public void OnPlayerBoost(float speedBoost, float duration)
    {
        if (playerBoost != null)
        {
            StopCoroutine(playerBoost);
        }
        playerBoost = StartCoroutine(PlayerBoost(speedBoost, duration));
    }

    private IEnumerator PlayerBoost(float speedBoost, float duration)
    {
        playerStats.MoveSpeed = baseMoveSpeed + speedBoost;
        playerStats.SprintSpeed = baseSprintSpeed + speedBoost;
        // playerCameraFollow.Lens.FieldOfView = originalFOV + 12;
        Coroutine fov = StartCoroutine(FOVSmooth(originalFOV, originalFOV+fOVBoost));

        yield return new WaitForSeconds(duration);

        StopCoroutine(fov);
        fov = StartCoroutine(FOVSmooth(originalFOV+fOVBoost, originalFOV));
        playerStats.MoveSpeed = baseMoveSpeed;
        playerStats.SprintSpeed = baseSprintSpeed;
        playerCameraFollow.Lens.FieldOfView = originalFOV;
    }

    // Local old man refuses to use 'modern' tweeners
    private IEnumerator FOVSmooth(float start, float end)
    {
        playerCameraFollow.Lens.FieldOfView = start;
        float time = 0f;
        while (time < fOVDuration)
        {
            playerCameraFollow.Lens.FieldOfView = Mathf.Lerp(start, end, fOVCurve.Evaluate(time/fOVDuration));
            time += Time.deltaTime;
            yield return null;
        }
        playerCameraFollow.Lens.FieldOfView = end;
    }

    public void OnFlashlight(InputValue value)
    {
        if (value.isPressed)
        {
            if (playerStats.IsFlashlightOn)
            {
                playerStats.IsFlashlightOn = false;
                flashlight.SetActive(false);
            }
            else
            {
                playerStats.IsFlashlightOn = true;
                flashlight.SetActive(true);
            }
        }
    }
}
