using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class BeanLight : MonoBehaviour
{
    [SerializeField] private float radius = 10f;
    [SerializeField] private float range = 16f;
    [SerializeField] private float damageCooldown = 0.5f;
    private bool isOnCooldown;
    private Light light;
    private LayerMask mask;
    
    private void Start()
    {
        light = GetComponent<Light>();
        mask = LayerMask.GetMask("Player");
        isOnCooldown = false;
    }

    private void Update()
    {
        if (Physics.SphereCast(transform.position, radius, Vector3.down, out RaycastHit hit, range, mask))
        {
            if (isOnCooldown) return;
            Player player = hit.collider.gameObject.GetComponentInParent<Player>();
            StartCoroutine(Cooldown());
            player.TakeDamage(20);
        }
    }

    private IEnumerator Cooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(damageCooldown);
        isOnCooldown = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, radius);
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down*range));
    }
}
