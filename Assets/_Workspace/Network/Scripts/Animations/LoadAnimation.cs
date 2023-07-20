using UnityEngine;

public class LoadAnimation : MonoBehaviour
{
    private const float _rotationSpeed = 500;

    private Transform _transform;

    private float _rotationZ;

    private void Awake() =>
        _transform = transform;

    private void Update() =>
        Rotate();

    private void Rotate() =>
        _transform.Rotate(
            new Vector3(
                x: 0,
                y: 0,
                z: _rotationZ - (_rotationSpeed * Time.deltaTime)));
}
