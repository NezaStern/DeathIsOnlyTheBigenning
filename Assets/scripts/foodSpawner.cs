using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSpawner : MonoBehaviour
{
    public GameObject food;

    public float spawnSpeed = 5;

    public int maxFood = 100, minFood = 10;

    public float raduos = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAtRandom", 0, spawnSpeed);
    }

    void SpawnAtRandom(/*GameObject objectToSpawn*/)
    {
        Vector2 randomPos = Random.insideUnitCircle * raduos;

        GameObject newFood = Instantiate(food, randomPos, Quaternion.identity);
    }
}
