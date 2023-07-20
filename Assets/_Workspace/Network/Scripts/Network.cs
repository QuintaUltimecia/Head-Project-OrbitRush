using UnityEngine;
using System.Globalization;

namespace Network
{
    public class Network
    {
        public string InstallReferrer { get; private set; }
        public ClientData ClientData { get; private set; }

        private DomainContainerSO _domainContainer;
        private ServerRequest _serverRequest;

        public Network(DomainContainerSO domainContainerSO)
        {
            _domainContainer = domainContainerSO;
        }

        public async void Start(System.Action failCallback, System.Action<Response> successCallback)
        {
            _serverRequest = new ServerRequest("GET", "X-Requested-With");

            InstallReferrerSDK.GetInstallReferrer((InstallReferrer) => 
                AdvertisingIDSDK.GetAndroidAdvertiserId((string advertisingID) =>
                    CreateClientData(advertisingID)));

            string webRequest = await _serverRequest.GetWebRequest(_domainContainer.Domain, ClientData);
            webRequest = Base64Convertor.ReturnFromBase64(webRequest);

            Debug.Log(webRequest);

            Response response = new Response(webRequest);

            if (response.ServerRequest == null || response.ServerRequest.error == true)
                failCallback.Invoke();
            else
                successCallback.Invoke(response);
        }

        private void CreateClientData(string advertisingId)
        {
            ClientData = new ClientData(
                clientID: SystemInfo.deviceUniqueIdentifier,
                installerName: InstallerNameSDK.GetInstallerName(),
                carrierCode: CultureInfo.CurrentCulture.Parent.ToString(),
                appDeviceType: SystemInfo.deviceType.ToString(),
                appLocale: CultureInfo.CurrentCulture.Name,
                appDeviceName: SystemInfo.deviceName,
                appClientID: SystemInfo.deviceUniqueIdentifier,
                appAdvertisingID: advertisingId,
                package: Application.identifier);

            Debug.Log("Client data created");
        }
    }
}
