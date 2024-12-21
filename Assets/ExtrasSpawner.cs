using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrasSpawner : MonoBehaviour
{
    public Transform Player;
    public GameObject[] EnemyShips;
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
            whereToSpawn = new Vector3 (transform.position.x, transform.position.y, Player.position.z + 235f);
            Instantiate (EnemyShips[UnityEngine.Random.Range(0,10)], whereToSpawn, Quaternion.identity);                                       
        }
    }    
        
}
