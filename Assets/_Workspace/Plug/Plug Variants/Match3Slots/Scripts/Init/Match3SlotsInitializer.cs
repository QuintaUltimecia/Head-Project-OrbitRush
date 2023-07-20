using UnityEngine;

namespace Match3Slots
{
    public class Match3SlotsInitializer : BasePlug
    {
        public override void ShowPlug()
        {

        }

        public void Subs()
        {
            //_plugPanel.GetPanel<MenuPanel>().GetButton<StartButton>().OnClick.AddListener(() => StartGame());
            //_plugPanel.GetPanel<GamePanel>().GetButton<SpinButton>().OnClick.AddListener(() => Spin());
        }

        public void StartGame()
        {
            //_plugPanel.ShowPanel<GamePanel>();

            //foreach (var item in _plugObjects)
            //{
            //    item.Show();
            //}
        }

        private void Spin()
        {
            //GetPlugObject<Grid>().Spin();
        }

        public override void Init(Canvas canvas, Camera camera = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
