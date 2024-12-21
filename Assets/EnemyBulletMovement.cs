using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 0.6f;
    public int waitTime = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.back * speed;
    }
    
    void OnTriggerEnter(Collider coll) 
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        } 

       if (coll.gameObject.CompareTag("EnemyBulletTimer"))
        {
            /*StartCoroutine(WaitForIt ());*/
            Destroy(gameObject, 0.5f);
        }   
    }    

    /*IEnumerator WaitForIt() {
            yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }   */  
}
