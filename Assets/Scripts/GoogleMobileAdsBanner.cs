using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class GoogleMobileAdsBanner : MonoBehaviour
{
    private BannerView bannerView;
    private string adUnitId;
    private bool TestAds = false;

    void Start()
    {        
        this.RequestBanner();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            this.bannerView.Hide();
        }
    }
    
    public void ShowAd()
    {
        this.bannerView.Show();
    }

    public void HideAd()
    {
        this.bannerView.Hide();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        // Test ads
        if (TestAds)
        {
            adUnitId = "ca-app-pub-3940256099942544/6300978111";
        }
        // Real ads
        if (!TestAds)
        {
            adUnitId = "ca-app-pub-3940256099942544/6300978111";
        }
#elif UNITY_IPHONE
            //adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the bottom of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        //this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }    
}
