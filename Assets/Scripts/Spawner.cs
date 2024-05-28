using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectToSpawn;
    public GameObject coin;
    public GameObject vendingMachine;

    float timeToNextSpawn;
    float timeToNextCoinSpawn;
    float timeToNextVendingMachineSpawn;
    float timeSinceLastSpawn = 0.0f;

    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 3.0f;

    void Start()
    {
        timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;

        if (timeSinceLastSpawn > minSpawnTime )
        {
            int selection = Random.Range(0, objectToSpawn.Length);

            Instantiate(objectToSpawn[selection], transform.position, Quaternion.identity);

            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timeSinceLastSpawn = 0.0f;
            Debug.Log(timeSinceLastSpawn);
        }
        if (timeSinceLastSpawn == 0.0f)
        {
            timeToNextCoinSpawn = Random.Range(0, 8);
            timeToNextVendingMachineSpawn = Random.Range(0, 5);

            if (timeToNextVendingMachineSpawn == 0)
            {
                Instantiate(vendingMachine, transform.position + new Vector3(0, 5, 0), Quaternion.identity);
            }
            if (timeToNextCoinSpawn == 1)
            {
                Instantiate(coin, transform.position + new Vector3(0, 2.5f, 0), Quaternion.identity);
            }
        }
    }
}
