using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnscript : MonoBehaviour
{

    public GameObject asteroid1;
    public GameObject asteroid2;
    public float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    IEnumerator SpawnAsteroids()
    {
    while (true)
    {
        // Choose a random asteroid
        GameObject asteroidToSpawn = Random.value > 0.5f ? asteroid1 : asteroid2;

        // Choose a random position within the screen boundaries
        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
        Vector2 spawnPosition = new Vector2(x, y);

        // Spawn the asteroid
        Instantiate(asteroidToSpawn, spawnPosition, Quaternion.identity);

        // Wait for a certain amount of time before spawning the next asteroid
        yield return new WaitForSeconds(2f);
    }
    }   
    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }
    void OnDrawGizmos()
    {
    // Draw a rectangle to represent the screen boundaries
    Gizmos.color = Color.red;
    Gizmos.DrawLine(new Vector2(xMin, yMin), new Vector2(xMax, yMin));
    Gizmos.DrawLine(new Vector2(xMax, yMin), new Vector2(xMax, yMax));
    Gizmos.DrawLine(new Vector2(xMax, yMax), new Vector2(xMin, yMax));
    Gizmos.DrawLine(new Vector2(xMin, yMax), new Vector2(xMin, yMin));
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
