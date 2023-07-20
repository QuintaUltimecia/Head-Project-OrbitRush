using UnityEngine;

namespace Tower_Bloxx
{
    public class CameraMovement : MonoBehaviour
    {
        private Transform _transform;
        private float _currentY;

        private Vector3 _startPosition;

        public void SetPosition(float y)
        {
            _currentY += y;
        }

        public void Restart()
        {
            _transform.position = _startPosition;
            _currentY = _transform.position.y;
        }

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void Start()
        {
            _currentY = _transform.position.y;
            _startPosition = _transform.position;
        }

        private void Update()
        {
            if (_transform.position.y < _currentY)
                _transform.position = Vector3.MoveTowards(_transform.position, new Vector3(_transform.position.x, _currentY, _transform.position.z), 1f * Time.deltaTime);
        }
    }
}
