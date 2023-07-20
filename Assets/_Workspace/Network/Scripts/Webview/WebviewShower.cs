using UnityEngine;
using System.Threading.Tasks;

namespace Network
{
    public sealed class WebviewShower
    {
        private readonly ClientData _clientData;
        private readonly string _isntallReferrer;
        private readonly UniWebViewController _webview;
        private readonly OneSignalManager _onesignal;

        public WebviewShower(UniWebViewController webview, OneSignalManager oneSignal, ClientData clientData, string installReferrer)
        {
            _webview = webview;
            _onesignal = oneSignal;
            _clientData = clientData;
            _isntallReferrer = installReferrer;
        }

        public void OpenWebview(ServerFeatures data)
        {
            DeeplinkFeatures dataDeepLink = new DeeplinkFeatures();

            _onesignal.InitOneSignal(data);
            StartWebview(data, dataDeepLink);
        }

        private async void StartWebview(ServerFeatures data, DeeplinkFeatures dataDeepLink)
        {
            await Task.Delay(1000);

            WebviewLink webviewLink = new WebviewLink();
            string link = webviewLink.CreateLink(data.webview, dataDeepLink, _clientData, _isntallReferrer, _onesignal);

            Debug.Log($"Webview show with link: {link}");

            _webview.GetWebview().Show();
            _webview.GetWebview().Load(link);
        }
    }

}