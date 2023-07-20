using Ugi.PlayInstallReferrerPlugin;

public static class InstallReferrerSDK 
{
    public static void GetInstallReferrer(System.Action<string> callBack)
    {
        PlayInstallReferrer.GetInstallReferrerInfo((installReferrerDetails) =>
        {
            string installReferrer = "null";

            if (installReferrerDetails.InstallReferrer != null)
            {
                installReferrer = $"{installReferrerDetails.InstallReferrer}&it={installReferrerDetails.InstallBeginTimestampSeconds}";

                callBack?.Invoke(installReferrer);
            }
            else
            {
                callBack?.Invoke(installReferrer);
            }
        });
    }
}
