using UnityEngine;
using Network;

public class EntryPoint 
{
    private WebviewShower _webviewShower;
    private Network.Network _network;

    private PlugInitializer _plugInitializer;
    private NetworkInitializer _networkInitializer;

    private AdsManager _adsManager;

    private Camera _camera;
    private Canvas _canvas;

    public EntryPoint(Canvas canvas, NetworkInitializer networkInitializer, PlugInitializer plugInitializer, Camera camera, AdsManager adsManager)
    {
        _networkInitializer = networkInitializer;
        _plugInitializer = plugInitializer;

        _camera = camera;
        _canvas = canvas;
        _adsManager = adsManager;
    }

    public void Start()
    {
        Init();
        GetGabage();
        Subs();

        if (Application.internetReachability == NetworkReachability.NotReachable)
            OpenPlug(); else StartNetwork();
    }

    private void Init()
    {
        _adsManager.Init();
    }

    private void Subs()
    {
        _canvas.worldCamera = _camera;
    }

    private void StartNetwork()
    {
        _network = new Network.Network(_networkInitializer.DomainContainer);
        _network.Start(

            failCallback: () => 
                OpenPlug(),
            successCallback: (Response response) => 
                OpenWebview(response));
    }

    private void OpenWebview(Response response)
    {
        Screen.orientation = ScreenOrientation.AutoRotation;

        _networkInitializer.UniWebViewController.Init(false, _canvas.GetComponent<RectTransform>());

        _webviewShower = new WebviewShower(
            _networkInitializer.UniWebViewController, 
            _networkInitializer.OneSignalManager, 
            _network.ClientData, 
            _network.InstallReferrer);

        _webviewShower.OpenWebview(response.ServerRequest);
    }

    private void OpenPlug()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        _plugInitializer.Init(_canvas, _camera);
        _plugInitializer.ShowPlug();
    }

    private void GetGabage()
    {
        int count = 0;

        GarbageCollection.MoreGarbage garbage = new GarbageCollection.MoreGarbage(count);
        GarbageCollection.BigMoreGarbage bigMoreGarbage = new GarbageCollection.BigMoreGarbage();
    }
}
