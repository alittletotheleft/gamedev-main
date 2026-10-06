using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;

    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
        }
    }

    public int MaxHealth
    {
        get => maxHealth;
        set
        {
            maxHealth = value < 0 ? 0 : value;
            if (health > maxHealth)
                health = maxHealth;
        }
    }

    public float MoveSpeed
    {
        get => moveSpeed;
        set
        {
            moveSpeed = value < 0f ? 0f : value;
        }
    }

    public float SprintSpeed
    {
        get => sprintSpeed;
        set
        {
            sprintSpeed = value < 0f ? 0f : value;
        }
    }
}
