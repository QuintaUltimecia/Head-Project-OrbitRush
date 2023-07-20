using UnityEngine;

public static class InstallerNameSDK
{
    public static string GetInstallerName()
    {
        string installerName;

#if UNITY_EDITOR
        installerName = "com.android.vending";
#elif PLATFORM_ANDROID
        installerName = Application.installerName;
#endif

        return installerName;
    }
}
