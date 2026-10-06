using UnityEngine;

public class ObstacleBobble : MonoBehaviour
{
    [SerializeField] private float yOffset = 2f;
    [SerializeField] private float duration = 1f;
    [SerializeField] private AnimationCurve curve;
    private Vector3 startPosition, endPosition;
    private float t = 0f;
    private bool bounced = false;

    private void Start()
    {
        startPosition = transform.position + Vector3.up * yOffset;
        endPosition = transform.position - Vector3.up * yOffset;
    }

    private void Update()
    {
        if (!bounced)
            t += Time.deltaTime;
        else
            t -= Time.deltaTime;

        transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(t / duration));

        if (!bounced && t > duration)
            bounced = true;
        else if (bounced && t < 0f)
            bounced = false;
    }
}
