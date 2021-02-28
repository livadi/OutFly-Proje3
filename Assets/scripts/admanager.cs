

using UnityEngine;
using System;
using GoogleMobileAds.Api;
public class admanager : MonoBehaviour
{
    private string App_ID = "ca-app-pub-6147388949201943~9373924034";
    private string interstitial_AD_ID = "ca-app-pub-6147388949201943/5357182629";
    private string rewardedvideo_AD_ID = "ca-app-pub-6147388949201943/3123252597";

    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;
    void Start()
    {
        MobileAds.Initialize(App_ID);
    }

    public void RequestInterstitial()
    {
        this.interstitial = new InterstitialAd(interstitial_AD_ID);
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
     
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();

        }
    }
    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
    }
    public void HandleOnAdOpened(object sender, EventArgs args)
    {
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        interstitial.Destroy();
    }
    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
    }

    public void RequestRewardBasedVideo()
    {
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardBasedVideo.LoadAd(request, rewardedvideo_AD_ID);
   
    }
  
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
    }
    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
    }
    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
    }
    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
    }
    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        rewardBasedVideo.OnAdLoaded -= HandleRewardBasedVideoLoaded;
        rewardBasedVideo.OnAdFailedToLoad -= HandleRewardBasedVideoFailedToLoad;
        rewardBasedVideo.OnAdOpening -= HandleRewardBasedVideoOpened;
        rewardBasedVideo.OnAdStarted -= HandleRewardBasedVideoStarted;
        rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdClosed -= HandleRewardBasedVideoClosed;
        rewardBasedVideo.OnAdLeavingApplication -= HandleRewardBasedVideoLeftApplication;
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        distancemeter.coin +=500;
       
    }
    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
    }
}