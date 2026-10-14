using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -1000)
        {
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
