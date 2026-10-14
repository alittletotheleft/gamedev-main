using UnityEngine;

// The same damn script
public class FloatBetween : MonoBehaviour
{
    [SerializeField] private float duration = 1.25f;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    private float t = 0f;
    private bool bounced = false;

    private void Start()
    {
        transform.position = startPosition;
    }

    private void Update()
    {
        if (!bounced)
            t += Time.deltaTime;
        else
            t -= Time.deltaTime;
        
        Vector3 position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(t / duration));
        transform.position = position;

        if (!bounced && t > duration)
            bounced = true;
        else if (bounced && t < 0f)
            bounced = false;
    }
}
