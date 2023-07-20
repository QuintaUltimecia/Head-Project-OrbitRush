using UnityEngine;

namespace Tower_Bloxx
{
    public class House : MonoBehaviour
    {
        public int ID { get; private set; }

        private Transform _transform;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _transform = transform;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Init(int id)
        {
            ID = id;
        }

        public void SetGravity(bool isActive)
        {
            _rigidbody2D.velocity = Vector3.zero;
            _rigidbody2D.isKinematic = !isActive;
        }

        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }
    }
}
