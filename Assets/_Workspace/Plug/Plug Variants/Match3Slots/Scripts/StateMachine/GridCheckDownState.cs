using System.Collections;
using System.Threading.Tasks;
using UnityEngine;


namespace Match3Slots
{
    public class GridCheckDownState : GridBaseState
    {
        private bool _isAction = false;

        public GridCheckDownState(IGridStateSwitcher stateSwitcher, int gridSize, GridItem[,] gridItems) :
            base(stateSwitcher, gridSize, gridItems)
        {

        }

        public override IEnumerator Spin() { yield return 0; }
        public override void CheckNeighbours() { }

        public async override void CheckDown()
        {
            int count = 0;

            for (int y = _gridSize - 1; y != -1; y--)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    bool isDown = _gridItems[x, y].IsCheckDown();
                    _gridItems[x, y].CheckDown(onStart: () => IncreamentCounter(), onComplete: () => DecreamentCounter());

                    if (isDown == false)
                    {
                        count++;
                    }
                }

                await Task.Delay(50);
            }

            if (count == 49)
            {
                _stateSwitcher.SwitchState<GridFullnessItemState>();
                Debug.Log("Switch state to GridFullnessItemState");
            }
        }

        public override void FullnessItem() { }

        public override void Start()
        {
            _isAction = false;
            CheckDown();
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

            Debug.Log($"Complete counter {_completeCounter}");

            if (_completeCounter == 0 && _isAction == false)
            {
                _isAction = true;

                Event();
            }
        }

        private async void Event()
        {
            await Task.Delay(350);
            _stateSwitcher.SwitchState<GridFullnessItemState>();
            Debug.Log("Switch state to GridFullnessItemState");
        }
    }
}
