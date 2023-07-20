using System.Collections;

namespace Slots
{
    public abstract class GridBaseState
    {
        protected readonly int _gridSize;
        protected readonly GridItem[,] _gridItems;

        protected int _completeCounter = 0;

        public IGridStateSwitcher _stateSwitcher;

        public GridBaseState(IGridStateSwitcher stateSwitcher, int gridSize, GridItem[,] gridItems)
        {
            _stateSwitcher = stateSwitcher;

            _gridSize = gridSize;
            _gridItems = gridItems;
        }

        public abstract IEnumerator Spin();
        public abstract void CheckNeighbours();
        public abstract void CheckDown();
        public abstract void FullnessItem();

        public abstract void Start();
        public abstract void Stop();

        public virtual void IncreamentCounter()
        {
            _completeCounter++;
        }

        public virtual void DecreamentCounter()
        {
            _completeCounter--;

            if (_completeCounter < 0)
                _completeCounter = 0;
        }
    }
}
