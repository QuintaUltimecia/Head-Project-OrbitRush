using UnityEngine;

namespace MobileUtility
{
    public class TelephonyManager
    {
        private readonly AndroidJavaObject _telephonyManager;

        public TelephonyManager()
        {
            _telephonyManager = new AndroidJavaObject("android.telephony.TelephonyManager");
        }

        public string GetSimCountry() =>
            _telephonyManager.Call<string>("getSimCountryIso");

        public string GetSimOperator() =>
            _telephonyManager.Call<string>("getSimOperator");

        public string GetNetworkCountryIso() =>
            _telephonyManager.Call<string>("getNetworkCountryIso");
    }
}