using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "ScriptableObjects/GameState")]
public class GameState : ScriptableObject
{
    [SerializeField] private bool isGameRunning;

    public bool IsGameRunning { get; set; }
}
