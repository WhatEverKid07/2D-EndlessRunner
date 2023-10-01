using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // create a public array of objects to spawn, we will fill this up using the unity editor
    public GameObject[] objectToSpawn;

    float timeToNextSpawn;// tracks how long we should wait before spwaning a new object
    float timeSinceLastSpawn = 0.0f;// tracks the line since we last spawned something

    public float minSpawnTime = 0.5f;// minimum amount of time between spawning objects
    public float maxSpawnTime = 3.0f;// maximun amount of time between spawning objects

    // Start is called before the first frame update
    void Start()
    {
        //random.range returns a random float between two values
        timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);

    }

    // Update is called once per frame
    void Update()
    {
        // add time.deltatime returns the amount of time passed since the last frame
        // this will create a float that counts up in seconds
        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;

        // if we've counted past the amount of time we need to wait
        if (timeSinceLastSpawn > minSpawnTime )
        {
            // use random.range to pick a number from 0 and the amount of items we have in our object list
            int selection = Random.Range(0, objectToSpawn.Length);

            //instantiate spawns a gameobject- in this case we tell it to spawn a gameobject from our objecttospawn list
            // the second parameter in the brackets tells it where to spawn, so we've entered the position of the spawner.
            //the third parameter is fr rotation, and quaternion.identity means no rotaion
            Instantiate(objectToSpawn[selection], transform.position, Quaternion.identity);

            //after spawning we slect a new random time for the next spawn and set our timer back to zero
            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timeSinceLastSpawn = 0.0f;        
        }

        

    }
}
