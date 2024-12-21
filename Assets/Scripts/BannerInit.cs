using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class BannerInit : MonoBehaviour
{
    private BannerView bannerView;
    public void Start()
    {
        

        this.RequestBanner();
        ShowAd();
        /*if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            bannerView.Hide();
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
             bannerView.Hide();
        }
        /*if (SceneManager.GetActiveScene().buildIndex == 2)
        {
              bannerView.Show();
        }*/
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-4457742425451127/1189849971";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    public void ShowAd()
    {
        bannerView.Show();
    }

    public void HideAd()
    {
        bannerView.Hide();
    }

    void Update()
    {
        
    }
}
