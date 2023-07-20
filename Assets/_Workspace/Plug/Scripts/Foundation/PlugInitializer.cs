using UnityEngine;

public class PlugInitializer : MonoBehaviour
{
    [SerializeField]
    private BasePlug _plug;

    private Canvas _canvas;
    private Camera _camera;

    public void Init(Canvas canvas, Camera camera)
    {
        _canvas = canvas;
        _camera = camera;
    }

    public void ShowPlug()
    {
        _plug.Init(_canvas, _camera);
        _plug.ShowPlug();
    }
}
