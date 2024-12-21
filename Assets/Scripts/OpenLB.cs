using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class OpenLB : MonoBehaviour
{
    private Button openLB;
    // Start is called before the first frame update
    void Start()
    {
        openLB = GetComponent<Button>();
        openLB.onClick.AddListener(LBButton);
    }

    // Update is called once per frame
    private void LBButton()
    {
        Social.ShowLeaderboardUI();
    }
}
