using System;
using UnityEngine;

public class PlatformButton : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!platform)
                return;

            platform.transform.Rotate(new Vector3(0f,45f,0f), Space.Self);
        }
    }
}
