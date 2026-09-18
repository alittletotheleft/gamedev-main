using UnityEngine;

public class UFO : MonoBehaviour
{
    public Transform body;
    public float rotationSpeed = 2.5f;

    void Update()
    {
        // body.transform.rotation.z += rotationSpeed * Time.deltaTime;
        body.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
