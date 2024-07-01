using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    [Header("안드로이드 id")]
    public string androidUnitId = "ca-app-pub-3940256099942544/6300978111";

    [Header("아이폰 id")]
    public string iosUnitId = "ca-app-pub-3940256099942544/2934735716";

    string adUnitId;

    BannerView _bannerView;

    public void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            //초기화 완료
        });

#if UNITY_ANDROID
        adUnitId = androidUnitId;
#elif UNITY_IOS
        adUnitId = iosUnitId;
#else
        adUnitId = "unexpected_platform";
#endif

        LoadAd();
    }

    public void LoadAd() //광고 로드
    {
        if (_bannerView == null)
        {
            CreateBannerView();
        }
        var adRequest = new AdRequest();

        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }

    public void CreateBannerView() //광고 보여주기
    {
        Debug.Log("Creating banner view");

        if (_bannerView != null)
        {
            DestroyAd();
        }

        _bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

    }


    private void ListenToAdEvents()
    {
        _bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + _bannerView.GetResponseInfo());
        };
        _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
        };
        _bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Banner view paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        _bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        _bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        _bannerView.OnAdFullScreenContentOpened += (null);
        {
            Debug.Log("Banner view full screen content opened.");
        };
        _bannerView.OnAdFullScreenContentClosed += (null);
        {
            Debug.Log("Banner view full screen content closed.");
        };
    }

    public void ShowAd() //광고 표시
    {
        if (_bannerView != null)
        {
            Debug.Log("Show banner ad.");
            _bannerView.Show();
        }
        else
        {
            LoadAd();
        }
    }

    public void HideAd() //광고 숨기기
    {
        if (_bannerView != null)
        {
            Debug.Log("Hide banner ad.");
            _bannerView.Hide();
        }
    }


    public void DestroyAd() //광고 제거
    {
        if (_bannerView != null)
        {
            Debug.Log("Destroying banner ad.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }
}