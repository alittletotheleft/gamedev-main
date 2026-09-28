using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 5f;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
