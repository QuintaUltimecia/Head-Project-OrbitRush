public class WebviewLink
{
    public WebviewLink() { }

    public string CreateLink(string webview, DeeplinkFeatures deeplinkFeatures, ClientData clientData, string installReferrer, OneSignalManager onesignal)
    {
        string newWebview = "";

        for (int i = 0; i < webview.Length; i++)
        {
            if (webview[i] == '?')
            {
                newWebview += webview[i];
                break;
            }
            else
            {
                newWebview += webview[i];
            }
        }

        string parameters =
            $"external_id={clientData.app_client_id}&" +
            $"creative_id=null&" +
            $"ad_campaign_id=null&" +
            $"source=null&" +
            $"sub_id_1={deeplinkFeatures.sub1}&" +
            $"sub_id_2={deeplinkFeatures.sub2}&" +
            $"sub_id_3={deeplinkFeatures.sub3}&" +
            $"sub_id_4={deeplinkFeatures.sub4}&" +
            $"sub_id_5={deeplinkFeatures.sub5}&" +
            $"stream_id={deeplinkFeatures.partnerStream}&" +
            $"campaign_name={deeplinkFeatures.partnerName}&" +
            $"advertising_id={clientData.app_advertising_id}&" +
            $"adid=null&" +
            $"install_referrer={installReferrer}&" +
            $"push_data={onesignal.GetAdditinalData()}";

        newWebview += parameters;

        return newWebview;
    }
}
