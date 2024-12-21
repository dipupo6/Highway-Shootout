using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.SocialPlatforms;


public class GPGSAuthentication : MonoBehaviour
{
    public static PlayGamesPlatform platform;
    public Text text;

    void Start(){
        if (platform == null){
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;

            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate((bool success) =>{
            if (success){
                Debug.Log("Logged in successfully");
                
            }
            else{
                Debug.Log("Log in failed");
                text.GetComponent<Text>().enabled = false;
            }
        });
        
    }
}
