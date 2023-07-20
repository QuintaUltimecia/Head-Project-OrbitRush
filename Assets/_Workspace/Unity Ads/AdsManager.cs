using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    public RewardedAds RewardedAds { get; private set; }

    [SerializeField]
    private bool _isTestMode;

    [SerializeField]
    private string _androidId;

    [SerializeField]
    private string _iosId;

    public void Init()
    {
        string id = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iosId : _androidId;

        Advertisement.Initialize(id, _isTestMode, this);

        RewardedAds = new RewardedAds();
    }

    public void OnInitializationComplete() { }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message) { }
}
