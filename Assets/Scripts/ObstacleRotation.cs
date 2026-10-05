using System;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
    }
}
