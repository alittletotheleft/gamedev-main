using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;

    public void Fire(Vector3 force)
    {
        rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
