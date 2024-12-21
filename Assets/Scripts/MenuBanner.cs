using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class MenuBanner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        Debug.Log("Ads Init");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
