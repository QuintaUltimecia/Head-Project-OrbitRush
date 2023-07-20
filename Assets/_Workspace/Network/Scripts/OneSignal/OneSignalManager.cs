using UnityEngine;
using OneSignalSDK;
using Newtonsoft.Json;

public class OneSignalManager : MonoBehaviour
{
    public string FileName { get; private set; } = "/oneSignalResponse.json";
    public string Path { get; private set; } = "/_Workspace/Network/Response/";

    private string _additionalData;

    private void _notificationOpened(NotificationOpenedResult result)
    {
        OneSignalResult data = JsonConvert.DeserializeObject<OneSignalResult>(JsonUtility.ToJson(result));

        RawPayLoad rawPayLoad = JsonConvert.DeserializeObject<RawPayLoad>(data.notification.rawPayload);

        string custom = AdditionalDataConvertor.ToJson(rawPayLoad.custom);
        CustomData customData = JsonConvert.DeserializeObject<CustomData>(custom);

        _additionalData = customData.a;

        DataSaver additionalData = new DataSaver("/additionalData.json", Path);
        additionalData.SaveData(customData.a);

        Debug.Log($"Notification opened");
    }

    public string GetAdditinalData()
    {
        DataSaver additionalData = new DataSaver("/additionalData.json", Path);

        _additionalData = additionalData.LoadStringFormat();

        if (string.IsNullOrEmpty(_additionalData) == true)
            _additionalData = "null";

        Debug.Log($"AdditionalData: {_additionalData}");

        return _additionalData;
    }

    public void InitOneSignal(ServerFeatures data)
    {
        if (!string.IsNullOrEmpty(data.onesignal.push_id))
        {
            OneSignal.Default.Initialize(data.onesignal.push_id);
            OneSignal.Default.NotificationOpened += _notificationOpened;

            Debug.Log($"Onesingal initialize with: {data.onesignal.push_id}");
        }
        else
        {
            Debug.Log($"Onesingal push id is empty: {data.onesignal.push_id}");
        }
    }

    public void SetTag(DeeplinkFeatures data)
    {
        OneSignal.Default.SendTag($"{data.partnerName}", data.partnerName);

        Debug.Log($"Onesingal set tag with: {data.partnerName}");
    }
}
