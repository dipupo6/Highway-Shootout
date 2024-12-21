using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 0.6f;
    public int waitTime = 7;
    public AudioClip bulletSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.forward * speed;
    }

    void OnTriggerEnter(Collider coll) 
    {
        if (coll.gameObject.CompareTag("EnemyShip"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            /*EnemyHealthBarScript.health -= 12.5f;*/
        } 

        if (coll.gameObject.CompareTag("BulletTimer"))
        {
            StartCoroutine(WaitForIt ());
            GetComponent<AudioSource>().PlayOneShot (bulletSound);
        }    
    }     

    IEnumerator WaitForIt() {
            yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    } 
}
