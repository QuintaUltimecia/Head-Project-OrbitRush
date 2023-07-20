using UnityEngine;
using UnityEngine.EventSystems;

public class ResourcesLoader : MonoBehaviour
{
    private string _mainCamera = "Main Camera";
    private string _canvas = "Canvas";
    private string _eventSystem = "EventSystem";

    private string _networkInitializer = "Network Initializer";
    private string _plugInitializer = "Plug Initializer";

    private string _advertisement = "Advertisement";

    private EntryPoint _entryPoint;

    private void Awake()
    {
        Instantiate(Resources.Load<EventSystem>(_eventSystem));

        _entryPoint = new EntryPoint(
            canvas: Instantiate(Resources.Load<Canvas>(_canvas)),
            networkInitializer: Instantiate(Resources.Load<NetworkInitializer>(_networkInitializer)),
            plugInitializer: Instantiate(Resources.Load<PlugInitializer>(_plugInitializer)),
            camera: Instantiate(Resources.Load<Camera>(_mainCamera)),
            adsManager: Instantiate(Resources.Load<AdsManager>(_advertisement)));
    }

    private void Start()
    {
        _entryPoint.Start();
    }
}
