using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : IUnityAdsLoadListener, IUnityAdsShowListener
{
    private string _androidAdUnityId = "Rewarded_Android";
    private string _iosAdUnityId = "Rewarded_iOS";

    private string _currentId;

    public System.Action OnAdShowComplete;

    public RewardedAds()
    {
        _currentId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iosAdUnityId : _androidAdUnityId;
    }

    public void LoadAd()
    {
        Advertisement.Load(_currentId, this);
    }

    public void ShowAd()
    {
        Advertisement.Show(_currentId, this);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) 
    { 
        if (placementId.Equals(_currentId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
            OnAdShowComplete?.Invoke();
    }

    public void OnUnityAdsShowClick(string placementId) { }
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }
    public void OnUnityAdsShowStart(string placementId) { }

    void IUnityAdsLoadListener.OnUnityAdsAdLoaded(string placementId) { }
    void IUnityAdsLoadListener.OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }
}
