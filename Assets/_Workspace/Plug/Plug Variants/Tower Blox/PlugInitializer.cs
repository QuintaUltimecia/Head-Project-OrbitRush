using Unity.VisualScripting;
using UnityEngine;

namespace Tower_Bloxx
{
    public class PlugInitializer : BasePlug
    {
        [SerializeField]
        private HeadPanel _headPanelPrefab;

        [SerializeField]
        private HeadObject _headObjectPrefab;

        private HeadPanel _headPanel;
        private HeadObject _headObject;

        private CameraMovement _cameraMovement;

        private void ShowRecord()
        {
            _headPanel.ShowInternalPanel<RecordsPanel>();
            _headPanel.GetInternalPanel<RecordsPanel>().MaxRecord.GetValue(RecordSaver.GetRecord());
        }

        private void BackToMenu()
        {
            _headPanel.ShowInternalPanel<MenuPanel>();
        }

        private void StartGame()
        {
            _headPanel.ShowInternalPanel<GamePanel>();

            _headObject.Holder.gameObject.SetActive(true);
            _headObject.Platform.gameObject.SetActive(true);
        }

        private void EndGame()
        {
            _headPanel.GetInternalPanel<EndGamePanel>().Show();

            _headObject.Holder.gameObject.SetActive(false);
            _headObject.Platform.gameObject.SetActive(false);
        }

        private void RestartGame()
        {
            _headObject.Holder.gameObject.SetActive(true);
            _headObject.Platform.gameObject.SetActive(true);

            _headObject.Holder.Restart();
            _headObject.Platform.Restart();
            _cameraMovement.Restart();

            _headPanel.ShowInternalPanel<GamePanel>();
            _headPanel.GetInternalPanel<GamePanel>().Counter.ResetCount();
        }

        private void OnTap()
        {
            _headObject.Holder.GetHouse();
            _headPanel.GetInternalPanel<GamePanel>().Counter.GetCount(1);
        }

        public override void Init(Canvas canvas, Camera camera)
        {
            _cameraMovement = camera.AddComponent<CameraMovement>();

            _headPanel = Instantiate(_headPanelPrefab, canvas.transform);
            _headObject = Instantiate(_headObjectPrefab);

            _headPanel.GetInternalPanel<MenuPanel>().GetInternalButton<StartButton>().OnClick = () => StartGame();
            _headPanel.GetInternalPanel<MenuPanel>().GetInternalButton<RecordsButton>().OnClick = () => ShowRecord();
            _headPanel.GetInternalPanel<RecordsPanel>().GetInternalButton<BackButton>().OnClick = () => BackToMenu();
            _headPanel.GetInternalPanel<GamePanel>().TapPanel.OnTap += () => OnTap();
            _headPanel.GetInternalPanel<GamePanel>().Counter.OnGetCount += (int value) => RecordSaver.SaveRecord(value);
            _headPanel.GetInternalPanel<EndGamePanel>().GetInternalButton<RestartButton>().OnClick += () => RestartGame();
            _headObject.Platform.OnCollision += () => EndGame();

            _headObject.Holder.Init(_cameraMovement);
        }

        public override void ShowPlug()
        {
            _headPanel.ShowInternalPanel<MenuPanel>();

            _headObject.Holder.gameObject.SetActive(false);
            _headObject.Platform.gameObject.SetActive(false);
        }
    }
}

