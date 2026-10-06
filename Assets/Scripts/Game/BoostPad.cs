using UnityEngine;
using UnityEngine.Events;

public class BoostPad : MonoBehaviour
{
    [SerializeField] private float speedBoost = 4f;
    [SerializeField] private float duration = 4f;
    [SerializeField] private UnityEvent<float, float> PlayerBoost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerBoost.Invoke(speedBoost, duration);
        }
    }
}
