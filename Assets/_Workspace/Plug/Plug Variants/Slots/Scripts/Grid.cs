using System;
using UnityEngine;
using System.Linq;

namespace Slots
{
    [RequireComponent(typeof(GridItemMovement))]
    public class Grid : BasePlugObject, IGridStateSwitcher
    {
        [SerializeField]
        private float _moveInterval = 0.5f;

        [SerializeField]
        private GridItem _prefab;

        private int _gridSize = 7;

        private GridItem[,] _gridItems;

        private GridBaseState _currentState;
        private GridBaseState[] _allStates;

        private Money _money;

        public void Init(Money money)
        {
            _money = money;
        }

        public void SwitchState<T>() where T : GridBaseState
        {
            var state = _allStates.FirstOrDefault(s => s is T);
            state.Start();

            _currentState.Stop();
            _currentState = state;
        }

        public GridItem GetGridItem(int x, int y)
        {
            return _gridItems[x, y];
        }

        public void Spin()
        {
            StartCoroutine(_currentState.Spin());
        }

        private void Start()
        {
            _gridItems = new GridItem[_gridSize, _gridSize];

            for (int x = 0; x < _gridSize; x++)
                for (int y = 0; y < _gridSize; y++)
                    _gridItems[x, y] = Instantiate(_prefab, transform);

            GridCreator gridCreator = new GridCreator();
            gridCreator.CreateGrid(_gridItems, _gridSize);

            for (int x = 0; x < _gridSize; x++)
                for (int y = 0; y < _gridSize; y++)
                {
                    _gridItems[x, y].Init(x, y, this);
                    _gridItems[x, y].OnReplace += () => _money.GetMoney(10);
                }

            _allStates = new GridBaseState[]
            {
                new GridSpinState(this, _gridSize, _gridItems),
                new GridMoveState(this, _gridSize, _gridItems),
                new GridCheckNeighbourState(this, _gridSize, _gridItems),
            };

            _currentState = _allStates[0];
        }
    }
}
