using System;
using UnityEngine;

public class PlatformButton : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private float rotateValue = 45f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!platform)
                return;

            platform.transform.Rotate(new Vector3(0f,rotateValue,0f), Space.Self);
        }
    }
}
