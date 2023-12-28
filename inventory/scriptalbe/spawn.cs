using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Prefab to spawn
    public Vector3 minPosition; // Minimum spawn position
    public Vector3 maxPosition; // Maximum spawn position
    public float spawnInterval = 3000; // Time interval between spawns in seconds

    void Start()
    {
        InvokeRepeating("SpawnRandomObject", 0f, spawnInterval);
    }

    void SpawnRandomObject()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-400, 400), // x position
            Random.Range(-400, 400), // y position
            Random.Range(0, 400)     // z position
        );

        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }
}