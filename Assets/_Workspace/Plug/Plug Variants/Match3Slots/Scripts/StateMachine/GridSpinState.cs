using System.Collections;
using UnityEngine;


namespace Match3Slots
{
    public class GridSpinState : GridBaseState
    {
        private float _moveInterval = 0.5f;

        public GridSpinState(IGridStateSwitcher stateSwitcher, int gridSize, GridItem[,] gridItems) :
            base(stateSwitcher, gridSize, gridItems)
        {

        }

        public override IEnumerator Spin()
        {
            _stateSwitcher.SwitchState<GridMoveState>();
            Debug.Log("Switch state to GridMoveState");

            for (int x = 0; x < _gridSize; x++)
            {
                for (int y = 0; y < _gridSize; y++)
                {
                    if (x == _gridSize - 1 && y == _gridSize - 1)
                        _gridItems[x, y].GridItemMovement.StartMove(() => OnComplete());
                    else _gridItems[x, y].GridItemMovement.StartMove();
                }

                yield return new WaitForSeconds(_moveInterval);
            }
        }

        public override void CheckNeighbours() { }
        public override void CheckDown() { }
        public override void FullnessItem() { }

        public override void Start()
        {

        }

        public override void Stop()
        {

        }

        public void OnComplete()
        {
            _stateSwitcher.SwitchState<GridCheckNeighbourState>();
            Debug.Log("Switch state to GridCheckNeighbourState");
        }
    }
}
