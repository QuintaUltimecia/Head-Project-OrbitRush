using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slots
{
    public class SlotsPlug : BasePlug
    {
        private Grid _grid;
        private Money _money;

        public override void Init(Canvas canvas, Camera camera = null)
        {

        }

        public override void ShowPlug()
        {

        }

        public void Subs()
        {
            //_plugPanel.GetPanel<MenuPanel>().GetButton<StartButton>().OnClick.AddListener(() => StartGame());

            //_money = _plugPanel.GetPanel<GamePanel>().Money;
           // _grid = GetPlugObject<Grid>();
            //_grid.Init(_money);

            //_plugPanel.GetPanel<GamePanel>().GetButton<SpinButton>().OnClick.AddListener(() => { _grid.Spin(); _money.RemoveMoney(20); });
        }

        private void StartGame()
        {
           // _plugPanel.ShowPanel<GamePanel>();
            _grid.Show();
        }
    }
}
