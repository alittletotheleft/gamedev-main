using UnityEngine;

public class PlatformHorizontalButton : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private float xValue = 1f;
    // [SerializeField]
    // private float xSpeed = 5f;
    [SerializeField]
    private Vector2 xClamps = new Vector2(-15f, 15f);
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!platform)
                return;

            platform.transform.Translate(Vector3.right * xValue * Time.deltaTime, Space.World);
            platform.transform.position = new Vector3(
                Mathf.Clamp(platform.transform.position.x, xClamps.x, xClamps.y),
                platform.transform.position.y,
                platform.transform.position.z
            );
        }
    }
}
