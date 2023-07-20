using UnityEngine;

public abstract class BasePlug : MonoBehaviour
{
    public abstract void Init(Canvas canvas, Camera camera);
    public abstract void ShowPlug();
}
