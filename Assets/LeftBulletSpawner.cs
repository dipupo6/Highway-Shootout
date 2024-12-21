using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBulletSpawner : MonoBehaviour
{
    public Transform Player;
    public GameObject Floor;
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
            whereToSpawn = new Vector3 (Player.position.x - 0.458f, transform.position.y, Player.position.z);
            Instantiate (Floor, whereToSpawn, Quaternion.identity);                                       
        }

        if(Score.score > 30)
        {
            spawnRate = 0.5f;
        }
    }    
        
}
