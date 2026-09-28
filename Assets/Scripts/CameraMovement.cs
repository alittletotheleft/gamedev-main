using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float cameraSmoothing = 5f;
    private Vector3 offset;
    private Vector3 original;

    private void Start()
    {
        offset = transform.position - playerTransform.position;
        original = transform.position;
    }

    private void Update()
    {
        Vector3 newPosition = playerTransform.position + offset;
        Vector3 clampedPosition = new Vector3(original.x, original.y, newPosition.z);
        transform.position = Vector3.Lerp(transform.position, clampedPosition, cameraSmoothing * Time.deltaTime);
    }
}
