using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Zombie prefab
    public Transform[] spawnPoints; // Array of spawn points
    public float spawnInterval = 3f; // Time between spawns

    private void Start()
    {
        Debug.Log("Spawner started!"); // Debug message
        InvokeRepeating(nameof(SpawnZombie), 0f, spawnInterval);
    }

    private void SpawnZombie()
    {
        if (spawnPoints.Length == 0 || zombiePrefab == null)
        {
            Debug.LogWarning("No spawn points or prefab assigned!");
            return;
        }

        // Pick a random spawn point
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Spawn zombie
        Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log($"Spawned zombie at {spawnPoint.position}");
    }
}
