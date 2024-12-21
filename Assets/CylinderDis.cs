using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderDis : MonoBehaviour
{
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
            GetComponent<BoxCollider>().enabled = false;
        }
    }  
}
