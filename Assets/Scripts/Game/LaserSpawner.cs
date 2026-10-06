using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct LaserSpawnInfo
{
    public GameObject laser;
    public Vector3 position;
    public float angle;
    public float moveSpeed;
}

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] private LaserSpawnInfo[] lasers;
    [SerializeField] private Transform laserSpawnPoint;
    [SerializeField] private Vector2 spawnCooldownRange = new Vector2(1.5f, 2.5f);
    private Coroutine laserSpawning;
    private bool isSpawning = false;

    public void StartGame()
    {
        if (isSpawning)
        {
            Debug.LogWarning($"[WARNING] Attempted to START already-running coroutine {laserSpawning.ToString()}.");
            return;
        }

        laserSpawning = StartCoroutine(LaserSpawning());
        isSpawning = true;
    }

    public void StopGame()
    {
        if (!isSpawning)
        {
            Debug.LogWarning($"[WARNING] Attempted to STOP already-stopped coroutine {laserSpawning.ToString()}.");
            return;
        }

        StopCoroutine(laserSpawning);
        laserSpawning = null;
        isSpawning = false;
    }

    private IEnumerator LaserSpawning()
    {
        while (true)
        {
            float cooldown = Random.Range(spawnCooldownRange.x, spawnCooldownRange.y);
            yield return new WaitForSeconds(cooldown);

            SpawnLaser();
        }
    }

    private void SpawnLaser()
    {
        int newLaserIndex = Random.Range(0, lasers.Length);
        GameObject newLaser = Instantiate(lasers[newLaserIndex].laser, laserSpawnPoint);
        newLaser.transform.SetLocalPositionAndRotation(lasers[newLaserIndex].position, Quaternion.Euler(0, 0, lasers[newLaserIndex].angle));
        
        Laser l = newLaser.GetComponent<Laser>();
        l.SetMoveSpeed(lasers[newLaserIndex].moveSpeed);
    }
}
