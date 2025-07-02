using UnityEngine;
using System.Collections;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab; 
    public Transform pointA;  
    public Transform pointB; 
    public int bricksPerBatch = 10; 
    public float spawnInterval = 0.01f; 

    void Start()
    {
        StartCoroutine(SpawnBricks());
    }

    IEnumerator SpawnBricks()
    {
        while (true)
        {
         
            for (int i = 0; i < bricksPerBatch; i++)
            {
                Vector3 spawnPosition = new Vector3(
                    Random.Range(pointA.position.x, pointB.position.x),
                    pointA.position.y,
                    0
                );

                Instantiate(brickPrefab, spawnPosition, Quaternion.identity); 
           
                yield return new WaitForSeconds(spawnInterval);
            }

            yield return new WaitForSeconds(spawnInterval); 
        }
    }
}
