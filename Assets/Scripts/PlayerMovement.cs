using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 0.6f;
    public GameObject Ground;
    public int waitTime = 3;
    public GameObject ScoreText;
    public GameObject ScoreText1;
    public GameObject ScoreText2;
    public GameObject GameText;
    public GameObject HighText;
    public GameObject MainCamera;
    public GameObject PauseButton;
    public GameObject RewButton;
    public GameObject SnowParticles;
    public GameObject TireRim;
    public GameObject TireRubber;
    public AudioClip ping;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource> ();
        Ground.GetComponent<FinishColor>().SetRandomColor();
        Ground.GetComponent<FinishColor>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector3.forward * speed;
        if(Score.score > 20)
        {
            speed = 6f;
        }
        if(Score.score > 20)
        {
            speed = 6.5f;
        }
        if(Score.score > 40)
        {
            speed = 7f;
        }
    }

    void OnTriggerEnter(Collider coll) 
    {
        if (coll.gameObject.CompareTag("ScoreCounter"))
        {
            Score.score += 1;
            GetComponent<AudioSource>().PlayOneShot (ping);
        }

        if (coll.gameObject.CompareTag("Spike"))
        {
            speed = 0f;
            transform.Rotate(0f, -70f, 80f);
            TireRim.GetComponent<TireRotate>().enabled = false;
            TireRubber.GetComponent<TireRotate>().enabled = false;
            GetComponent<ExampleLeftRight>().enabled = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<ParticleSystem>().enableEmission = false;
            GetComponent<BoxCollider>().enabled = false;
			SnowParticles.SetActive(false);
            ScoreText.GetComponent<TextMeshProUGUI>().enabled = false;
            MainCamera.GetComponent<CameraFollow>().enabled = false;
            StartCoroutine(WaitForIt ());
        }
    }  

    IEnumerator WaitForIt() {
            yield return new WaitForSeconds(waitTime);
            Time.timeScale = 0;
            MainCamera.SetActive(false);
            /*BannerObject.GetComponent<BannerInit>().ShowAd();*/
            RewButton.SetActive(true);
            SceneManager.LoadScene("RestartScene", LoadSceneMode.Additive);
            ScoreText1.SetActive(true);
            ScoreText2.GetComponent<TextMeshProUGUI>().enabled = true;
            PauseButton.SetActive(false);
            GameText.SetActive(true);
            HighText.SetActive(true);
            /*Social.LoadScores (
              GPGSIds.leaderboard_highscores, scores => {
              if (scores.Length > 0){
                  foreach (IScore score in scores){
                      if (Social.localUser.id == score.userID){
                          highscoreText.text = "BEST SCORE: " + score.formattedValue;
                          return;
                       }
                       else{
                        highscoreText.text = "BEST SCORE: " + Score.highscore;
                       }  
                   }
              }
              
            });   */
    }    
}
