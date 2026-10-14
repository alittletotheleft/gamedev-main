using UnityEngine;

// The same damn script
public class RotateBetween : MonoBehaviour
{
    [SerializeField] private float duration = 1.25f;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Vector3 startRotation;
    [SerializeField] private Vector3 endRotation;
    private float t = 0f;
    private bool bounced = false;

    private void Start()
    {
        transform.eulerAngles = startRotation;
    }

    private void Update()
    {
        if (!bounced)
            t += Time.deltaTime;
        else
            t -= Time.deltaTime;
        
        Vector3 rotation = Vector3.Lerp(startRotation, endRotation, curve.Evaluate(t / duration));
        transform.eulerAngles = rotation;

        if (!bounced && t > duration)
            bounced = true;
        else if (bounced && t < 0f)
            bounced = false;
    }
}
