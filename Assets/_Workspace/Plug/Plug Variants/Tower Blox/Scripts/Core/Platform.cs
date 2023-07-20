using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tower_Bloxx
{
    public class Platform : MonoBehaviour
    {
        public Transform Transform { get; private set; }

        public System.Action OnCollision;

        private List<Collision2D> _collisions = new List<Collision2D>();

        private void Awake()
        {
            Transform = transform;
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (_collisions.Count > 0)
            {
                if (collision.transform.TryGetComponent(out House house))
                    if (house.ID != 0)
                        _collisions.Add(collision);
            }
            else
            {
                _collisions.Add(collision);
            }

            if (_collisions.Count >= 2) { OnCollision.Invoke(); }
        }

        public void Restart()
        {
            _collisions.Clear();
        }
    }
}

