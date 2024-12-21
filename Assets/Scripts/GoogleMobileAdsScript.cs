using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using Google.Play.Instant;

public class GoogleMobileAdsScript : MonoBehaviour
{
    private RewardedAd rewardedAd;
    private string adUnitId;
    private bool TestAds = false;
    public GameObject ScoreText2;
    public Button RewardButton;

    void Start()
    {
        if(rewardedAd == null)
        {
            CreateAndLoadRewardedAd();
        }
    }

    public void CreateAndLoadRewardedAd()
    {
#if UNITY_ANDROID
        // Test ads
        if (TestAds)
        {
            adUnitId = "ca-app-pub-3940256099942544/5224354917";
        }
        // Real ads
        if (!TestAds)
        {
            adUnitId = "ca-app-pub-7821291602827838/7453491799";
        }
#elif UNITY_IPHONE
            //adUnitId = "ca-app-pub-3940256099942544/5224354917";
#else
            adUnitId = "unexpected_platform";
#endif

        if (rewardedAd != null)
        {
           rewardedAd.Destroy();
           rewardedAd = null;
        }
        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.LoadAdError.GetMessage());
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.AdError.GetMessage());
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        this.CreateAndLoadRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, EventArgs args)
    {
            Score.score += Score.score;
            /*Social.ReportScore(Score.score, GPGSIds.leaderboard_highscores, (bool success) =>{
            if (success){
            Debug.Log("Score submitted");
            }
            });*/
            /*ScoreText2.GetComponent<Score>().LoadBestScore();*/
            rewardedAd.Destroy();
    }

    public void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
            RewardButton.interactable = false;
        }
    }
}
