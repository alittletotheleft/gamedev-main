using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private float yOffset = 5f;
    private bool used = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !used)
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            player.SetSpawnpoint(transform.position + Vector3.up * yOffset);
            used = true;
        }
    }
}
