using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yodo1.MAS;
public class Adversisment : MonoBehaviour
{
    [SerializeField] GameObject _backgroundBlur;
    private Yodo1U3dBannerAdView bannerAdView;
    private void Start()
    {
        Yodo1AdBuildConfig config = new Yodo1AdBuildConfig().enableUserPrivacyDialog(true);
        Yodo1U3dMas.SetAdBuildConfig(config);
        Yodo1U3dMas.InitializeSdk();
        InitializeRewardedAds();
        this.RequestBanner();
    }

    private void InitializeRewardedAds()
    {
        // �������� �������
        Yodo1U3dMasCallback.Rewarded.OnAdOpenedEvent += OnRewardedAdOpenedEvent;
        Yodo1U3dMasCallback.Rewarded.OnAdClosedEvent += OnRewardedAdClosedEvent;
        Yodo1U3dMasCallback.Rewarded.OnAdReceivedRewardEvent += OnAdReceivedRewardEvent;
        Yodo1U3dMasCallback.Rewarded.OnAdErrorEvent += OnRewardedAdErorEvent;
    }

    private void OnRewardedAdOpenedEvent()
    {
        Debug.Log("[Yodo1 Mas] ���������� � �������������� �������");
    }

    private void OnAdReceivedRewardEvent()
    {
        ContinueGame();
    }
   private void OnRewardedAdClosedEvent()
    {
        
        
    }

    private void OnRewardedAdErorEvent(Yodo1U3dAdError adError)
    { 
    }


    private void ContinueGame()
    {
        _backgroundBlur.SetActive(false);
        GameStats.ContinueGame();
    }

    public void ShowReward()
    {
        bool isLoaded = Yodo1U3dMas.IsRewardedAdLoaded();
        if (isLoaded)
        {
            Yodo1U3dMas.ShowRewardedAd();
        }
    }




    private void RequestBanner()
    {
        // Clean up banner before reusing
        if (bannerAdView != null)
        {
            bannerAdView.Destroy();
        }

        // Create a 320x50 banner at top of the screen
        bannerAdView = new Yodo1U3dBannerAdView(Yodo1U3dBannerAdSize.Banner, Yodo1U3dBannerAdPosition.BannerTop | Yodo1U3dBannerAdPosition.BannerHorizontalCenter);
        // Load banner ads, the banner ad will be displayed automatically after loaded
        bannerAdView.LoadAd();
    }
}

