using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class HiddenObject : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material invisibleMaterial;
    [SerializeField] private float radius;
    private MeshRenderer mesh;
    private readonly Collider[] cols  = new Collider[10];
    private LayerMask mask;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mask = LayerMask.GetMask("Player");
    }
    
    private void Update()
    {
        // Debug.Log($"OverlapSphereNonAlloc: {Physics.OverlapSphereNonAlloc(transform.position, radius, cols, mask)}");
        if (Physics.OverlapSphereNonAlloc(transform.position, radius, cols, mask) > 0)
        {
            mesh.enabled = true;
            if (playerStats.IsFlashlightOn)
            {
                mesh.material = normalMaterial;
            }
            else
            {
                mesh.material = invisibleMaterial;
            }
        }
        else
        {
            mesh.enabled = false;
        }
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawSphere(transform.position, radius);
    // }
}
