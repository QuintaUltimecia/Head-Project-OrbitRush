using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

namespace Slots
{
    public class GridCheckNeighbourState : GridBaseState
    {
        public GridCheckNeighbourState(IGridStateSwitcher stateSwitcher, int gridSize, GridItem[,] gridItems) :
            base(stateSwitcher, gridSize, gridItems)
        {

        }

        public override IEnumerator Spin() { yield return 0; }

        public override void CheckNeighbours()
        {
            int count = 0;

            for (int x = 0; x < _gridSize; x++)
            {
                for (int y = 0; y < _gridSize; y++)
                {
                    bool isNeighbour = _gridItems[x, y].ConnectNeighbour(onStart: () => IncreamentCounter(), onComplete: () => DecreamentCounter());

                    if (isNeighbour == false)
                        count++;
                }
            }

            if (count == 49)
            {
                _stateSwitcher.SwitchState<GridSpinState>();
                Debug.Log("Switch state to GridSpinState");
            }
        }

        public override void CheckDown() { }
        public override void FullnessItem() { }

        public override void Start()
        {
            Check();
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

            if (_completeCounter == 0)
            {
                _stateSwitcher.SwitchState<GridSpinState>();
                Debug.Log("Switch state to GridSpinState");
            }
        }

        private async void Check()
        {
            await Task.Delay(1);
            CheckNeighbours();
        }
    }
}
