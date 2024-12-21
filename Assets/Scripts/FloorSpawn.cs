using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawn : MonoBehaviour
{
    public Transform Player;
    public GameObject Floor;
    float randX;
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
            randX = Random.Range(-2.77f, 2.77f);
            whereToSpawn = new Vector3 (randX, transform.position.y, Player.position.z + 35f);
            Instantiate (Floor, whereToSpawn, Quaternion.identity);                                       
        }

        if(Score.score > 50)
        {
            spawnRate = 3f;
        }
    }    
        
}
