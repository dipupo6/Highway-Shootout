using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMove : MonoBehaviour
{
    // Movement Speed (0 means don't move)
    public float speed = 0;
    
    // Switch Movement Direction every x seconds
    public float switchTime = 2;

    void Start() {
        // Initial Movement Direction
        GetComponent<Rigidbody>().velocity = Vector3.up * speed;
        
        // Switch every few seconds
        InvokeRepeating("Switch", 0, switchTime);
    }
    
    void Switch() {
        GetComponent<Rigidbody>().velocity *= -1;
    }    
    
}
