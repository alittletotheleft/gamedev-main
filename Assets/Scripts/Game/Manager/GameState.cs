using UnityEngine;

[CreateAssetMenu(fileName="GameState", menuName="Scriptable Objects/GameState", order=0)]
public class GameState : ScriptableObject
{
    [SerializeField] private bool isGameRunning;
    [SerializeField] private int currentLevelID;

    public bool IsGameRunning {
        get => isGameRunning;
        set
        {
            isGameRunning = value;
        }
    }

    public int CurrentLevelID
    {
        get => currentLevelID;
        set
        {
            currentLevelID = value;
        }
    }
}
