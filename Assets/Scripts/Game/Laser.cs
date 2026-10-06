using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private int damage = 20;

    public void SetMoveSpeed(float _moveSpeed)
    {
        moveSpeed = _moveSpeed;
    }

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
            Player player = other.GetComponentInParent<Player>();
            player?.TakeDamage(damage);
            // Debug.Log("Player hit oooooggssssshhhhh");
        }
    }
}
