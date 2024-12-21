using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public Transform Player;
    public GameObject[] Obstacles;
    float randY;
    Vector3 whereToSpawn;
    public int sTime = 2;
    public float spawnRate = 1f;
    float nextSpawn = 0f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > nextSpawn) {
            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector3 (transform.position.x, transform.position.y, Player.position.z + 20f);
            Instantiate (Obstacles[UnityEngine.Random.Range(0,3)], whereToSpawn, Quaternion.identity);                                       
        }
    }    
        
}
