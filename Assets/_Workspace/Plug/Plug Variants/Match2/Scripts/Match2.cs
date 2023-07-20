using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match2
{
    public class Match2 : MonoBehaviour
    {
        [SerializeField]
        private int _gridSize = 5;

        [SerializeField]
        private float _offset = 215f;

        [SerializeField]
        private ItemContainer _itemContainerPrefab;

        private List<ItemContainer> _itemContainers;

        private List<ItemContainer> _duplicateItems = new List<ItemContainer>();

        private List<int> _map = new List<int>();

        public System.Action OnGameComplete;
        public System.Action OnMoves;

        public int CheckDuplicates()
        {
            return _duplicateItems.Count;
        }

        public void AddDuplicateItems(ItemContainer item)
        {
            if (_duplicateItems.Count < 2)
            {
                _duplicateItems.Add(item);
            }

            if (_duplicateItems.Count == 2)
            {
                StartCoroutine(DuplicateItemsAlphaDelay());

                OnMoves.Invoke();
            }
        }

        public void StartMacth3()
        {
            if (_itemContainers != null)
            {
                foreach (var item in _itemContainers)
                {
                    Destroy(item);
                }

                _itemContainers.Clear();
                _map.Clear();
            }

            CreateItemContainers();
        }

        private IEnumerator DuplicateItemsAlphaDelay()
        {
            yield return new WaitForSeconds(1f);

            if (_duplicateItems[0].Item.ID == _duplicateItems[1].Item.ID)
            {
                int count = 0;

                for (int i = 0; i < _itemContainers.Count; i++)
                    if (_itemContainers[i].Item.IsSelected == true)
                        count++;

                Debug.Log(count);

                if (count == _itemContainers.Count)
                    OnGameComplete?.Invoke();

                _duplicateItems.Clear();
            }
            else
            {
                _duplicateItems[0].Item.SetAlpha(true);
                _duplicateItems[1].Item.SetAlpha(true);

                _duplicateItems.Clear();
            }
        }

        private void CreateItemContainers()
        {
            _itemContainers = new List<ItemContainer>();

            float offsetX = -322.5f;
            float offsetY = -322.5f;

            for (int x = 0; x < _gridSize; x++)
            {
                for (int y = 0; y < _gridSize; y++)
                {
                    ItemContainer itemContainer = Instantiate(_itemContainerPrefab, transform);

                    itemContainer.transform.localPosition = new Vector3(offsetX + x * _offset, offsetY + y * _offset, 0);
                    itemContainer.Init(this);

                    _itemContainers.Add(itemContainer);
                }
            }

            foreach (var itemContainer in _itemContainers)
            {
                itemContainer.Item.SelectItem(GetRandomInt());
            }
        }

        private int GetRandomInt()
        {
            int random = Random.Range(0, 8);
            int count = 0;

            foreach (var item in _map)
                if (item == random)
                    count++;

            if (count == 2)
            {
                random = GetRandomInt();
            }
            else 
                _map.Add(random);

            return random;
        }
    }
}
