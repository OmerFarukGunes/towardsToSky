using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
public class rAdsScript : MonoBehaviour
{
    private RewardBasedVideoAd rAd;
    string rAdId = "ca-app-pub-7256860357889667/9766747338";
    public Button rewardButton;
    void Start()
    {
        rewardButton.interactable = false;
        rAd = RewardBasedVideoAd.Instance;
        rAd.OnAdRewarded += videoRewarded;
        rAd.OnAdClosed += videClosed;
        requestAds();
    }
    private void requestAds()
    {
        AdRequest request = new AdRequest.Builder().Build();
        rAd.LoadAd(request, rAdId);
    }
    private void videoRewarded(object sender, EventArgs e)
    {
        reward();
    }
    private void videClosed(object sender, EventArgs e)
    {
        requestAds();
    }

    public void ShowAds()
    {
        rAd.Show();
    }
    private void reward()
    {
        int coin = PlayerPrefs.GetInt("collectCoin");
        coin += 50;
        PlayerPrefs.SetInt("collectCoin", coin);
        rewardButton.interactable = false;
    }
    private void Update()
    {
        if (rAd.IsLoaded())
            rewardButton.interactable = true;
        else
            rewardButton.interactable = false;
    }
}
