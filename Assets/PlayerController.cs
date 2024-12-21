using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 0.6f;
    public int destroyBullets;
    public int waitTime = 3;
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    float cubesPivotDistance;
    Vector3 cubesPivot;
    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;
    public GameObject RightBulletSpawner;
    public GameObject LeftBulletSpawner;
    public GameObject ScoreText;
    public GameObject ScoreText1;
    public GameObject ScoreText2;
    public GameObject GameText;
    public GameObject HighText;
    public GameObject PauseButton;
    public GameObject RewButton;
    public GameObject HealthBar;
    public AudioClip exp;
    public Text highscoreText;
    public GameObject MainCamera;
    public GameObject CameraShake;
    public GameObject body;
    public GameObject grill;
    public GameObject wheel1;
    public GameObject wheel2;
    public GameObject wheel3;
    public GameObject wheel4;
    public GameObject BannerObject;
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
        rb.velocity = Vector3.forward * speed;
        if(Score.score >= 10f && Score.score < 20f)
        {
            speed = 25f;
        }

        if(Score.score >= 20f && Score.score <= 30f)
        {
            speed = 30f;
        }

        if(Score.score > 30f)
        {
            speed = 35f;
        }
    }

    void OnTriggerEnter(Collider coll) 
    {
        if (coll.gameObject.CompareTag("EnemyBullet"))
        {
            destroyBullets += 1;
            HealthBarScript.health -= 1.5625f;
            if (HealthBarScript.health == 0f)  
            {
                explode();
                speed = 0f;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                GetComponent<AudioSource>().PlayOneShot (exp);
                HealthBar.SetActive(false);
                body.GetComponent<MeshRenderer>().enabled = false;
                grill.GetComponent<MeshRenderer>().enabled = false;
                wheel1.GetComponent<MeshRenderer>().enabled = false;
                wheel2.GetComponent<MeshRenderer>().enabled = false;
                wheel3.GetComponent<MeshRenderer>().enabled = false;
                wheel4.GetComponent<MeshRenderer>().enabled = false;
                StartCoroutine(WaitForIt ());
                GetComponent<BoxCollider>().enabled = false;
                RightBulletSpawner.SetActive(false);
                LeftBulletSpawner.SetActive(false);
                CameraShake.GetComponent<CameraShake>().ShakeIt();
            }
        }

        if (coll.gameObject.CompareTag("EnemyShip"))
        {
            explode();
            speed = 0f;
            GetComponent<AudioSource>().PlayOneShot (exp);
            HealthBar.SetActive(false);
            rb.constraints = RigidbodyConstraints.FreezeAll;
            body.GetComponent<MeshRenderer>().enabled = false;
            grill.GetComponent<MeshRenderer>().enabled = false;
            wheel1.GetComponent<MeshRenderer>().enabled = false;
            wheel2.GetComponent<MeshRenderer>().enabled = false;
            wheel3.GetComponent<MeshRenderer>().enabled = false;
            wheel4.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(WaitForIt ());
            GetComponent<BoxCollider>().enabled = false;
            RightBulletSpawner.SetActive(false);
            LeftBulletSpawner.SetActive(false);
            CameraShake.GetComponent<CameraShake>().ShakeIt();
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

    IEnumerator WaitForIt() 
    {
            yield return new WaitForSeconds(waitTime);
            Time.timeScale = 0;
            SceneManager.LoadScene("RestartScene", LoadSceneMode.Additive);
            ScoreText1.SetActive(true);
            ScoreText.SetActive(false);
            ScoreText2.GetComponent<Text>().enabled = true;
            GameText.SetActive(true);
            HighText.SetActive(true);
            RewButton.SetActive(true);
            PauseButton.SetActive(false);
            BannerObject.GetComponent<GoogleMobileAdsBanner>().ShowAd();
    }        
}
