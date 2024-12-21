using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKitScript : MonoBehaviour
{
    public GameObject Handle;
    public AudioClip healthInc;
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
        if (coll.gameObject.CompareTag("Player"))
        {
            HealthBarScript.health = 100f;
            GetComponent<AudioSource>().PlayOneShot (healthInc);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Handle.GetComponent<MeshRenderer>().enabled = false;
        }
    }    
}
