using UnityEngine;

// Kinda sucked in practice
public class NaturalShake : MonoBehaviour
{
    [SerializeField] private Vector2 offset = new (1f, 1f);
    [SerializeField] private float scale = 10f;
    private Vector3 originalRotation;
    private int seed;

    private void Start()
    {
        originalRotation = transform.eulerAngles;
        seed = Random.Range(0,10000);
    }

    private void Update()
    {
        Vector3 newRotation = new (
            originalRotation.x + Mathf.PerlinNoise(seed + Time.time / scale, seed + Time.time / scale) * offset.x,
            originalRotation.y + Mathf.PerlinNoise(seed + Time.time / scale, seed + Time.time / scale) * offset.y,
            originalRotation.z
        );
        Debug.Log($"Rotation of {gameObject.name}: {newRotation}");
        transform.eulerAngles = newRotation;
    }
}
