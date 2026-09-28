using UnityEngine;

public class Bedrock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Eeeeehhhhh
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            player.Reset();
            Debug.Log("boogsh");
        }
    }
}
