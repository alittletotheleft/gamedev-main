using UnityEngine;

public class SpotlightRotation : MonoBehaviour
{
    [SerializeField] private Transform lamp;
    [SerializeField] private float duration = 2.5f;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Vector2 angles = new Vector2(-40, -25);
    private float t = 0f;
    private bool bounced = false;

    private void Start()
    {
        lamp.transform.eulerAngles = new Vector3(0, 0, angles.x);
    }

    private void Update()
    {
        if (!bounced)
            t += Time.deltaTime;
        else
            t -= Time.deltaTime;
        
        // float rotation = Mathf.Lerp(angles.x, angles.y, t / duration);
        float rotation = Mathf.Lerp(angles.x, angles.y, curve.Evaluate(t / duration));
        lamp.transform.eulerAngles = new Vector3(0, 0, rotation);

        if (!bounced && t > duration)
            bounced = true;
        else if (bounced && t < 0f)
            bounced = false;
    }
}
