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
}

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] private LaserSpawnInfo[] lasers;
    [SerializeField] private Transform laserSpawnPoint;
    [SerializeField] private Vector2 spawnCooldownRange = new Vector2(1.5f, 2.5f);
    private Coroutine laserSpawning;
    private bool isSpawning = false;

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            laserSpawning = StartCoroutine(LaserSpawning());
            isSpawning = true;
        }
        else
            Debug.LogWarning($"[WARNING] Attempted to start already-running coroutine {laserSpawning.ToString()}.");
    }

    public void StopSpawning()
    {
        if (isSpawning)
        {
            StopCoroutine(laserSpawning);
            laserSpawning = null;
            isSpawning = false;
        }
        else
            Debug.LogWarning($"[WARNING] Attempted to stop already-stopped coroutine {laserSpawning.ToString()}.");
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
    }
}
