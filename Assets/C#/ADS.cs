using UnityEngine;
using GoogleMobileAds.Api;
public class ADS : MonoBehaviour
{
    public BannerView bannerView;
    public AdRequest newBanner;
     string bannerId = "ca-app-pub-7256860357889667/3062594410";
    public void Start()

    {
        MobileAds.Initialize(giveBanner => { });
        
        banner();
    }
    private void banner()
    {
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);
        newBanner= new AdRequest.Builder().Build();
        bannerView.LoadAd(newBanner);
    }
}
