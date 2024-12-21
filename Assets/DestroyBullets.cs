using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour
{
    public GameObject RightBullet;
    public GameObject LeftBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider coll) 
    {
       if (coll.gameObject.CompareTag("PlayerBullet"))
        {
            /*Destroy(RightBullet, 3f);
            Destroy(LeftBullet, 3f);
            Debug.Log("Collision");*/
        } 
    }      
}
