using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Match2
{
    public class Item : MonoBehaviour
    {
        public int ID { get; private set; }
        public bool IsSelected { get; private set; }

        [SerializeField]
        private List<Sprite> _sprites;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Start()
        {
            _image.color = new Color(1, 1, 1, 0);
        }

        public void SetAlpha(bool isActive)
        {
            if (isActive == true)
            {
                _image.color = new Color(1, 1, 1, 0);
                IsSelected = false;
            }
            else
            {
                _image.color = new Color(1, 1, 1, 1);
                IsSelected = true;
            }
        }

        public void SelectItem(int index)
        {
            ID = index;
            _image.sprite = _sprites[index];
        }
    }
}

