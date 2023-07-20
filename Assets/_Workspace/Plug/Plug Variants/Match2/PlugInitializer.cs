using UnityEngine;

namespace Match2
{
    public class PlugInitializer : BasePlug
    {
        [SerializeField]
        private HeadPanel _headPanelPrefab;

        private HeadPanel _headPanel;

        public override void Init(Canvas canvas, Camera camera = null)
        {
            _headPanel = Instantiate(_headPanelPrefab, canvas.transform);

            _headPanel.GetInternalPanel<MenuPanel>().GetInternalButton<StartButton>().OnClick += () => StartGame();
            _headPanel.GetInternalPanel<GamePanel>().Match2.OnGameComplete += () => EndGame();
            _headPanel.GetInternalPanel<WinPanel>().GetInternalButton<RestartButton>().OnClick += () => StartGame();
            _headPanel.GetInternalPanel<GamePanel>().Match2.OnMoves += () => _headPanel.GetInternalPanel<GamePanel>().Points.AddPoints(1);
        }

        public override void ShowPlug()
        {
            _headPanel.Show();
            _headPanel.ShowInternalPanel<MenuPanel>();
        }

        private void StartGame()
        {
            _headPanel.ShowInternalPanel<GamePanel>();
            _headPanel.GetInternalPanel<GamePanel>().Match2.StartMacth3();
            _headPanel.GetInternalPanel<GamePanel>().Points.RemovePoints();
        }

        private void EndGame()
        {
            _headPanel.ShowInternalPanel<WinPanel>();
        }
    }
}
