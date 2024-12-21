using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitRotate : MonoBehaviour
{
    public float rotSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (Vector2.up * rotSpeed);
    }
}
