using _Project.Scripts.UI.Entry;

namespace _Project.Scripts.UI.Interfaces
{
    public interface IGameView
    {
        public void Initialize(IGameController controller, GameConfig config);
    }
}