using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private UnityEvent PlayerGoal;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameState.IsGameRunning)
        {
            PlayerGoal.Invoke();
        }
    }
}
