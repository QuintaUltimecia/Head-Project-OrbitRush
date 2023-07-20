using UnityEngine;
using System.Collections;


namespace Match3Slots
{
    public class GridItemMovement : MonoBehaviour
    {
        public System.Action OnMoveComplete;

        [SerializeField]
        private float _moveSpeed;

        private Transform _transform;

        private Coroutine _moveRoutine;

        private Vector2[] _directions;

        public void StartMove(System.Action onLastComplete = null)
        {
            if (_moveRoutine != null)
                return;

            _moveRoutine = StartCoroutine(MoveDown(_directions[0], delegate
            {
                _transform.position = _directions[2];
                _moveRoutine = StartCoroutine(MoveDown(_directions[1], () => ClearMoveRoutine(onLastComplete)));

                OnMoveComplete?.Invoke();
            }));
        }

        private void Awake()
        {
            _transform = transform;
        }

        private void Start()
        {
            _moveRoutine = null;

            _directions = new Vector2[]
            {
            new Vector2(_transform.position.x, -7),
            new Vector2(_transform.position.x, _transform.position.y),
            new Vector2(_transform.position.x, 7),
            };
        }

        private void ClearMoveRoutine(System.Action onLastComplete)
        {
            onLastComplete?.Invoke();

            StopCoroutine(_moveRoutine);
            _moveRoutine = null;
        }

        private IEnumerator MoveDown(Vector2 direction, System.Action onComplete = null)
        {
            while ((Vector2)_transform.position != direction)
            {
                _transform.position = Vector2.MoveTowards(_transform.position, direction, _moveSpeed * Time.deltaTime);
                yield return new WaitForSeconds(Time.deltaTime);
            }

            onComplete?.Invoke();
        }
    }
}
