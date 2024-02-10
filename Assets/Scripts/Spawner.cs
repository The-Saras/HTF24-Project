using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   public GameObject[] prefabsToSpawn; // Array of GameObjects to spawn
    public int numberOfObjects = 3; // Number of objects to spawn
    public Vector3 spawnAreaSize = new Vector3(10f, 0f, 10f); // Size of the area where objects will spawn
    public float spawnInterval = 1f; // Time interval between spawns

    private float nextSpawnTime;

    void Update()
    {
        
        if (Time.time >= nextSpawnTime)
        {
            
            for (int i = 0; i < numberOfObjects; i++)
            {
                
                GameObject randomPrefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

                
                Vector3 randomPosition = new Vector3(
                    transform.position.x + Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                    transform.position.y + Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f),
                    transform.position.z + Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
                );

                Instantiate(randomPrefab, randomPosition, Quaternion.identity);
            }

           
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
