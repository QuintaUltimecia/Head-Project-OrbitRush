using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public sealed class ServerRequest
{
    private readonly string _requestType;
    private readonly string _requestHeader;

    public ServerRequest(string requestType, string requestHeader)
    {
        _requestType = requestType;
        _requestHeader = requestHeader;
    }

    public async Task<string> GetWebRequest(string url, ClientData clientData)
    {
        var clientJson = JsonUtility.ToJson(clientData);
        var clientBase64 = Base64Convertor.ReturnInBase64(clientJson);

        var uwr = new UnityWebRequest(url + clientBase64, _requestType);
        uwr.downloadHandler = new DownloadHandlerBuffer();
        uwr.SetRequestHeader(_requestHeader, clientData.package);

        Debug.Log("Wait send request...");

        await uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
            Debug.Log("Connectiond Error");
        else
            Debug.Log("Connectiond Success");

        string webRequest = uwr.downloadHandler.text;

        uwr.Dispose();

        return webRequest;
    }
}