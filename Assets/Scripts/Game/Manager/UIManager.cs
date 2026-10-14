using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [Header("GUIs")]
    [SerializeField] private GameObject gameGUI;
    [SerializeField] private GameObject levelSelectGUI;

    public void Reset()
    {
        gameGUI.SetActive(false);
        levelSelectGUI.SetActive(true);
    }

    public void StartGame()
    {
        gameGUI.SetActive(true);
        levelSelectGUI.SetActive(false);
    }
}
