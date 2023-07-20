using System.Collections;


namespace Match3Slots
{
    public class GridMoveState : GridBaseState
    {
        public GridMoveState(IGridStateSwitcher stateSwitcher, int gridSize, GridItem[,] gridItems) :
            base(stateSwitcher, gridSize, gridItems)
        {

        }

        public override IEnumerator Spin() { yield return 0; }
        public override void CheckNeighbours() { }
        public override void CheckDown() { }
        public override void FullnessItem() { }

        public override void Start()
        {

        }

        public override void Stop()
        {

        }
    }
}
