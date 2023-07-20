using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tower_Bloxx
{
    public class Holder : MonoBehaviour
    {
        [SerializeField]
        private House _housePrefab;

        [SerializeField]
        private Transform _housePoint;

        private CameraMovement _cameraMovement;

        private Transform _transform;

        private float _speed = 50f;
        private float _z;

        [SerializeField]
        private List<House> _houses = new List<House>();
        private House _lastHouse;

        private bool _isRotate = false;
        private Coroutine _createRoutine;

        public void Init(CameraMovement cameraMovement)
        {
            _cameraMovement = cameraMovement;
            transform.parent = _cameraMovement.transform;
        }

        private void Awake()
        {
            _transform = transform;
        }

        private void Start()
        {
            CreateHouse();
            _z = _transform.eulerAngles.z;
        }

        private void CreateHouse()
        {
            _lastHouse = Instantiate(_housePrefab, _transform);
            _lastHouse.SetPosition(_housePoint.position);
            _lastHouse.SetGravity(false);
        }

        private void Update()
        {
            if (_isRotate == false)
            {
                Quaternion rotation = Quaternion.Euler(0f, 0f, _z);

                _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, 10f * Time.deltaTime);
                _z -= _speed * Time.deltaTime;

                if (_z < -15)
                    _isRotate = true;
            }
            else
            {
                Quaternion rotation = Quaternion.Euler(0f, 0f, _z);

                _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, 10f * Time.deltaTime);
                _z += _speed * Time.deltaTime;

                if (_z > 15)
                    _isRotate = false;
            }
        }

        private IEnumerator CreateHouseWithDelay()
        {
            yield return new WaitForSeconds(2f);

            CreateHouse();

            if (_houses.Count % 4 == 0)
            {
                _cameraMovement.SetPosition(4f);
            }

            _createRoutine = null;
        }

        public void GetHouse()
        {
            if (_createRoutine == null) 
            {
                _lastHouse.SetGravity(true);
                _lastHouse.transform.parent = null;
                _lastHouse.Init(_houses.Count);
                _houses.Add(_lastHouse);

                _createRoutine = StartCoroutine(CreateHouseWithDelay());
            }
        }

        public void Restart()
        {
            foreach (var item in _houses)
                Destroy(item.gameObject);

            _houses.Clear();

            if (_lastHouse != null)
                Destroy(_lastHouse.gameObject);

            _createRoutine = null;

            CreateHouse();
        }
    }
}
