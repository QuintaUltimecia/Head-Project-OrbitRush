
namespace Match3Slots
{
    public interface IGridStateSwitcher
    {
        public void SwitchState<T>() where T : GridBaseState;
    }
}
