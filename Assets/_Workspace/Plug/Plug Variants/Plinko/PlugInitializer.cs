using UnityEngine;

namespace Plinko
{
    public class PlugInitializer : BasePlug
    {
        [SerializeField]
        private HeadPanel _headPanelPrefab;

        [SerializeField]
        private CoinManager _coinManagerPrefab;

        [SerializeField]
        private Grid _gridPrefab;

        private HeadPanel _headPanel;
        private CoinManager _coinManager;
        private Grid _grid;

        public override void Init(Canvas canvas, Camera camera = null)
        {
            InstantiateObjects(canvas);
            Subs();
        }

        public override void ShowPlug()
        {
            _coinManager.Hide();
            _grid.Hide();

            _headPanel.Show();

            _headPanel.ShowInternalPanel<MenuPanel>();
        }

        private void InstantiateObjects(Canvas canvas)
        {
            _headPanel = Instantiate(_headPanelPrefab, canvas.transform);
            _coinManager = Instantiate(_coinManagerPrefab);
            _grid = Instantiate(_gridPrefab);

            _coinManager.Init(_grid.HeadItem, _headPanel.GetInternalPanel<GamePanel>().Money);
        }

        private void Subs()
        {
            _headPanel.GetInternalPanel<MenuPanel>().GetInternalButton<StartButton>().OnClick = () => StartGame();
            _headPanel.GetInternalPanel<GamePanel>().GetInternalButton<GreenButton>().OnClick = () => _coinManager.SellCoin(0);
            _headPanel.GetInternalPanel<GamePanel>().GetInternalButton<OrangeButton>().OnClick = () => _coinManager.SellCoin(1);
            _headPanel.GetInternalPanel<GamePanel>().GetInternalButton<RedButton>().OnClick = () => _coinManager.SellCoin(2);
        }

        private void StartGame()
        {
            _coinManager.Show();
            _grid.Show();

            _headPanel.ShowInternalPanel<GamePanel>();
        }
    }
}
