using UnityEngine;

namespace Slots
{
    public interface IGridObject
    {
        public void SetScale(Vector3 localScale);
        public void SetPosition(Vector2 localPosition);

        public Vector2 GetColliderSize();
    }
}
