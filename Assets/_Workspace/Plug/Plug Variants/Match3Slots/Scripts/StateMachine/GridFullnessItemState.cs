using System.Collections;
using System.Threading.Tasks;
using UnityEngine;


namespace Match3Slots
{
    public class GridFullnessItemState : GridBaseState
    {
        private bool _isAction = false;

        public GridFullnessItemState(IGridStateSwitcher stateSwitcher, int gridSize, GridItem[,] gridItems) :
            base(stateSwitcher, gridSize, gridItems)
        {

        }

        public override IEnumerator Spin() { yield return 0; }
        public override void CheckNeighbours() { }
        public override void CheckDown() { }

        public async override void FullnessItem()
        {
            for (int y = _gridSize - 1; y != -1; y--)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    _gridItems[x, y].FullnessItem(onStart: () => IncreamentCounter(), () => DecreamentCounter());
                }

                await Task.Delay(100);
            }
        }

        public override void Start()
        {
            _isAction = false;
            FullnessItem();
        }

        public override void Stop()
        {

        }

        public override void IncreamentCounter()
        {
            base.IncreamentCounter();
        }

        public override void DecreamentCounter()
        {
            base.DecreamentCounter();

            if (_completeCounter == 0 && _isAction == false)
            {
                _isAction = true;

                _stateSwitcher.SwitchState<GridCheckNeighbourState>();
                Debug.Log("Switch state to GridCheckNeighbourState");
            }
        }
    }
}
