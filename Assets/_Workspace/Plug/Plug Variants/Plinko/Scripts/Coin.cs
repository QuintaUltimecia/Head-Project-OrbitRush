using UnityEngine;

namespace Plinko
{
    public class Coin : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed = 1f;

        private GridItem _targetItem;

        private Transform _transform;

        private ColorContainer _colorContainer;
        private CoinContainer _coinContainer;

        private Money _money;
        private int _bet;

        public void Init(GridItem gridItem, ColorContainer color, Money money, int bet)
        {
            _targetItem = gridItem;
            _transform.position = gridItem.transform.position;
            _colorContainer = color;
            _money = money;
            _bet = bet;
        }

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (_targetItem != null)
            {
                _transform.position = Vector3.MoveTowards(_transform.position, _targetItem.transform.position, _moveSpeed * Time.deltaTime);

                if (_transform.position == _targetItem.transform.position)
                {
                    int random = Random.Range(0, 2);

                    switch (random)
                    {
                        case 0:
                            if (_targetItem.GridItemLeft != null)
                                _targetItem = _targetItem.GridItemLeft;
                            else
                            {
                                GetAllCoinsContainer();
                                _targetItem = null;
                            }
                            break;
                        case 1:
                            if (_targetItem.GridItemLeft != null)
                                _targetItem = _targetItem.GridItemRight;
                            else
                            {
                                GetAllCoinsContainer();
                                _targetItem = null;
                            }
                            break;
                    }
                }
            }
            else
            {
                _transform.position = Vector3.MoveTowards(_transform.position, _coinContainer.transform.position, _moveSpeed * Time.deltaTime);

                if (_transform.position == _coinContainer.transform.position)
                {
                    Complete();
                }
            }
        }

        private void GetAllCoinsContainer()
        {
            switch (_colorContainer)
            {
                case ColorContainer.green:
                    _coinContainer = _targetItem.AllCoinContainers.GreenContainer.GetContainer(_targetItem.ID);
                    break;
                case ColorContainer.orange:
                    _coinContainer = _targetItem.AllCoinContainers.OrangeContainer.GetContainer(_targetItem.ID);
                    break;
                case ColorContainer.red:
                    _coinContainer = _targetItem.AllCoinContainers.RedContainer.GetContainer(_targetItem.ID);
                    break;
                default:
                    break;
            }
        }

        private void Complete()
        {
            _money.GetMoney(_bet, _coinContainer.Multiplier);

            gameObject.SetActive(false);
        }

    }
}
