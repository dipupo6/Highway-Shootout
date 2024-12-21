using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
/*using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;*/

 public class Score : MonoBehaviour
 {
     public static int highscore;
     public static int score;
     Text text;
     
     
 
     // Set highscoreText up in the inspector.
     public Text highscoreText;
 
     void Awake()
     {
         text = GetComponent<Text>();
         score = 0;
         highscore = score;
         highscore = PlayerPrefs.GetInt("highscore");
          
     }
     
     void Start() {
          /*if (!PlayGamesPlatform.Instance.IsAuthenticated()){
            highscoreText.text = "BEST SCORE: " + highscore;
         }  
          score = 0;*/
     }

     void Update()
     {
         if (score > highscore)
         {
             highscore = score;
             PlayerPrefs.SetInt("highscore", highscore);
         }
         text.text = "" + score;
         
        
     }
 }