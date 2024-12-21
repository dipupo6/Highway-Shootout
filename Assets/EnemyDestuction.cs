using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyDestuction : MonoBehaviour
{
    public int destroyBullets;
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    float cubesPivotDistance;
    Vector3 cubesPivot;
    public int waitTime = 3;
    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;
    public GameObject RightBulletSpawner;
    public GameObject LeftBulletSpawner;
    public AudioClip exp;
    public GameObject EnemyVehicle;
    public GameObject HealthBarImage;
    public GameObject HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll) 
    {
        if (coll.gameObject.CompareTag("PlayerBullet"))
        {
            destroyBullets += 1;
            HealthBar.GetComponent<EnemyHealthBarScript>().ReduceHealth();
            if (destroyBullets == 10)  
            {
                explode();
                Score.score += 1;
                GetComponent<AudioSource>().PlayOneShot (exp);
                EnemyVehicle.SetActive(false);
                GetComponent<BoxCollider>().enabled = false;
                RightBulletSpawner.SetActive(false);
                LeftBulletSpawner.SetActive(false);
                HealthBarImage.SetActive(false);
            }
        }  

        if (coll.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
        } 
    }

    public void explode() {


        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++) {
            for (int y = 0; y < cubesInRow; y++) {
                for (int z = 0; z < cubesInRow; z++) {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders) {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y, int z) {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        Destroy(piece, UnityEngine.Random.Range(0.5f, 5f));
        piece.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
