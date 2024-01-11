using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spawnInterval = 3f;
    public float objectLifetime = 2f;

    void Start()
    {
        // Start coroutine to spawn and destroy objects at specific intervals
        StartCoroutine(SpawnAndDestroyObject());
    }

    IEnumerator SpawnAndDestroyObject()
    {
        while (true)
        {
            // Spawn the object
            GameObject newObj = Instantiate(objectPrefab, GetRandomPosition(), Quaternion.identity);

            // Destroy the object after a certain period
            yield return new WaitForSeconds(objectLifetime);

            Destroy(newObj);

            // Allow the next object to be created after a certain period
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-18f, 18f);
        float yPosition = -5f;
        return new Vector3(randomX, yPosition, 0f);
    }
}

