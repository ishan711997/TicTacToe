using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Events;
public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    private string appID = "ca-app-pub-6351610926806883~9183853742";

    static int loadCount = 0;

// **************Banner Ad Id & var****************
    private BannerView bannerView;
    private string bannerID = "ca-app-pub-6351610926806883/5282403615";

// **************Interstitial Ad Id & var****************
    private InterstitialAd fullscreenAd;
    private string fullscreenAdID = "ca-app-pub-6351610926806883/6074652289";

    private void Awake() {
        if(instance == null){
            instance = this;
        }else{
            Destroy(this);
        }
    }

    private void Start() {
        
        RequestBanner();

        if (loadCount % 5 == 0)  // only show ad every third time
        {
            RequestFullScreenAd();
        }
        loadCount++;
    }

// ************************Banner Ad********************
    public void RequestBanner(){
        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);

        //we make an empty request sothat we can load our banner
        AdRequest request = new AdRequest.Builder().Build();

        // after above line we load our ad in empty request
        bannerView.LoadAd(request);

        bannerView.Show();
    }

    // for Hiding in the game lvl
    public void HideBanner(){
        bannerView.Hide();
    }

// ********************Interstitial Ad********************
    public void RequestFullScreenAd(){
        fullscreenAd = new InterstitialAd(fullscreenAdID);

        AdRequest request = new AdRequest.Builder().Build();

        fullscreenAd.LoadAd(request);
    }

    // for interstitial we make another fn and check that ad is loaded or not
    public void ShowFullScreenAd(){
        if(fullscreenAd.IsLoaded()){
            fullscreenAd.Show();
        }else{
            RequestFullScreenAd();
        }
    }
   

}
