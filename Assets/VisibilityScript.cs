using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityScript : MonoBehaviour
{
    public GameObject RightBulletSpawner;
    public GameObject LeftBulletSpawner;
    // Start is called before the first frame update
    void Start()
    {
        RightBulletSpawner.GetComponent<RightBulletSpawner>().enabled = false;
        LeftBulletSpawner.GetComponent<LeftBulletSpawner>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameVisible()
    {
        RightBulletSpawner.GetComponent<RightBulletSpawner>().enabled = true;
        LeftBulletSpawner.GetComponent<LeftBulletSpawner>().enabled = true;
    }

    void OnBecameInvisible()
    {
        RightBulletSpawner.GetComponent<RightBulletSpawner>().enabled = false;
        LeftBulletSpawner.GetComponent<LeftBulletSpawner>().enabled = false;
    }
}
