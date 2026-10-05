using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private void Update()
    {
        if (transform.position.z <= -160)
        {
            DestroySelf();
        }
        
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit oooooggssssshhhhh");
        }
    }
}
