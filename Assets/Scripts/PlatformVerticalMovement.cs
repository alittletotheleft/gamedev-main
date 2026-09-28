using UnityEngine;

public class PlatformVerticalMovement : MonoBehaviour
{
    [SerializeField]
    private float yOffset = 2.5f;
    [SerializeField]
    private float duration = 2.5f;
    private Vector3 originalPosition;
    private float time = 0f;
    private bool bounced = false;

    private void Start()
    {
        originalPosition = transform.position;
    }

    // Weird
    private void Update()
    {
        if (!bounced)
            time += Time.deltaTime;
        else
            time -= Time.deltaTime;

        transform.position = Vector3.Lerp(originalPosition + Vector3.down * yOffset, originalPosition + Vector3.up * yOffset, time / duration);
        
        if (!bounced && time > duration)
            bounced = true;
        else if (bounced && time < 0f)
            bounced = false;
    }
}
