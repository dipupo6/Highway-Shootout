using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner  : MonoBehaviour
{
    public GameObject[] Vehicles;
    public Transform Player;
    Vector3 whereToSpawn;
    public float spawnRate = 1f;
    float nextSpawn = 0f;
    float randX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn) {
            randX = Random.Range (-2.77f, 2.77f);
            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector3 (randX, transform.position.y, Player.position.z + 30f);
            Instantiate (Vehicles[UnityEngine.Random.Range(0,7)], whereToSpawn, Quaternion.identity);                                        
        }
    }
}
