using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialRandomizer : MonoBehaviour
{
    public Material newMaterial;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = newMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
