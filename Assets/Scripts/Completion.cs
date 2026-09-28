using UnityEngine;

public class Completion : MonoBehaviour
{
    [SerializeField]
    private GameObject message;

    private void Start()
    {
        message.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            message.SetActive(true);
        }
    }
}
