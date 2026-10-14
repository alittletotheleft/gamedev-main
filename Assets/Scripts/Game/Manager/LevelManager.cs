using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [Header("Levels")]
    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject level2;
    private Transform levelParent;
    private GameObject currentLevel;

    public void StartGame()
    {
        LoadLevel(gameState.CurrentLevelID);
    }

    private void LoadLevel(int id)
    {
        GameObject newLevel;
        switch (id)
        {
            case 1:
            default:
                newLevel = level1;
                break;
            case 2:
                newLevel = level2;
                break;
        }
        currentLevel = Instantiate(newLevel, levelParent);
    }
}
