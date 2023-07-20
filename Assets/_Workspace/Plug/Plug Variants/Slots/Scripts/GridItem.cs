using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Slots
{
    [RequireComponent(typeof(GridItemMovement))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class GridItem : BasePlugObject, IGridObject
    {
        [field: SerializeField]
        public Vector2 GridID { get; private set; }
        [field: SerializeField]
        public int ID { get; private set; }

        public GridItemMovement GridItemMovement { get; private set; }

        public System.Action OnReplace;

        [SerializeField]
        private List<Sprite> _spritePool;

        [SerializeField]
        private float _scaleSpeed = 2f;

        private Grid _grid;

        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _boxCollider2D;
        private Transform _transform;

        private Vector2[] _neighborIDs;

        private Coroutine _scaleRoutine;
        private Coroutine _moveRoutine;

        private Vector3 _defaultScale;
        private Vector3 _defaultPosition;

        private int _neighbourCount = 3;

        public void Init(int x, int y, Grid grid)
        {
            _grid = grid;
            _defaultScale = _transform.localScale;
            _defaultPosition = _transform.localPosition;
            GridID = new Vector2(x, y);

            _neighborIDs = new Vector2[]
            {
                new Vector2(GridID.x - 1, GridID.y),
                new Vector2(GridID.x + 1, GridID.y),
            };

            ReplaceItem(Random.Range(0, _spritePool.Count));
        }

        public bool ConnectNeighbour(System.Action onStart, System.Action onComplete)
        {
            List<GridItem> neighborurs = new List<GridItem>();

            int count = 0;

            for (int i = 0; i < _neighborIDs.Length; i++)
            {
                GridItem gridItem = GetNeightbour((int)_neighborIDs[i].x, (int)_neighborIDs[i].y);

                if (gridItem != null && gridItem.ID == ID)
                {
                    neighborurs.Add(gridItem);
                    gridItem.ConnectNeighbour(ref neighborurs, onStart, onComplete);

                    count++;
                }
            }

            if (count == 0 && neighborurs.Count > _neighbourCount)
            {
                foreach (var item in neighborurs)
                {
                    item.ReplaceWithAnimate(Random.Range(0, _spritePool.Count), onStart, onComplete);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public void ConnectNeighbour(ref List<GridItem> neighborurs, System.Action onStart, System.Action onComplete)
        {
            if (neighborurs == null)
                neighborurs = new List<GridItem>();

            int count = 0;

            for (int i = 0; i < _neighborIDs.Length; i++)
            {
                GridItem gridItem = GetNeightbour((int)_neighborIDs[i].x, (int)_neighborIDs[i].y);

                if (gridItem != null && gridItem.ID == ID)
                {
                    if (neighborurs.Contains(gridItem) == false)
                    {
                        neighborurs.Add(gridItem);
                        gridItem.ConnectNeighbour(ref neighborurs, onStart, onComplete);

                        count++;
                    }
                }
            }

            if (count == 0 && neighborurs.Count > _neighbourCount)
            {
                foreach (var item in neighborurs)
                {
                    item.ReplaceWithAnimate(Random.Range(0, _spritePool.Count), onStart, onComplete);
                }
            }
        }

        public void ReplaceWithAnimate(int index, System.Action onStart, System.Action onComplete)
        {
            if (_scaleRoutine != null)
                return;

            onStart?.Invoke();

            _scaleRoutine = StartCoroutine(_transform.ScaleRoutine((_defaultScale * 1.5f), _scaleSpeed, () =>
            {
                _scaleRoutine = StartCoroutine(_transform.ScaleRoutine(_defaultScale, _scaleSpeed, () =>
                {
                    _scaleRoutine = null;

                    OnReplace?.Invoke();
                    onComplete?.Invoke();
                }));
            }));
        }

        public void ReplaceItem(int index)
        {
            ID = index;
            _spriteRenderer.sprite = _spritePool[index];
        }

        public Vector2 GetColliderSize() =>
            _boxCollider2D.size;

        public void SetPosition(Vector2 localPosition) =>
            _transform.localPosition = localPosition;

        public void SetScale(Vector3 localScale) =>
            _transform.localScale = localScale;

        protected override void Awake()
        {
            base.Awake();

            GridItemMovement = GetComponent<GridItemMovement>();

            _spriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _transform = transform;
        }

        private void OnEnable()
        {
            GridItemMovement.OnMoveComplete += () => ReplaceItem(Random.Range(0, _spritePool.Count));
        }

        private void OnDisable()
        {
            GridItemMovement.OnMoveComplete -= () => ReplaceItem(Random.Range(0, _spritePool.Count));
        }

        private GridItem GetNeightbour(int x, int y)
        {
            try
            {
                return _grid.GetGridItem(x, y);
            }
            catch
            {
                return null;
            }
        }
    }
}
