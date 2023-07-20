using UnityEngine;

namespace Slots
{
    public class GridCreator
    {
        private float _normalize = 1f;
        private float _halfSize = 2f;

        public void CreateGrid(IGridObject[,] gridObjects, int gridSize)
        {
            if (gridObjects == null)
                return;

            float itemScale = _normalize / gridSize;

            float increamentSize = gridObjects[0, 0].GetColliderSize().x / gridSize;
            float posX = -increamentSize * (gridSize / _halfSize) + (increamentSize / _halfSize);
            float posY = increamentSize * (gridSize / _halfSize) - (increamentSize / _halfSize);

            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    gridObjects[x, y].SetScale(new Vector3(itemScale, itemScale, 1f));
                    gridObjects[x, y].SetPosition(new Vector2(posX, posY));

                    posX += increamentSize;
                }

                posX = -increamentSize * (gridSize / _halfSize) + (increamentSize / _halfSize);
                posY -= increamentSize;
            }
        }
    }
}
