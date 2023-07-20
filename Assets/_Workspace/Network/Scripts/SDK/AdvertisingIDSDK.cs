public static class AdvertisingIDSDK
{
    public static void GetAndroidAdvertiserId(System.Action<string> callBack)
    {
        string advertisingID = "null";

        MiniIT.Utils.AdvertisingIdFetcher.RequestAdvertisingId(advertisingId =>
        {
            advertisingID = advertisingId;

            callBack?.Invoke(advertisingID);
        });
    }
}
