using _Project.Scripts.UI.Model;

namespace _Project.Scripts.UI.Interfaces
{
    public interface IGameController
    {
        void AcceptForm(GameData data);
        GameData GetForm();
        void ResetForm();
        
        string IncreaseProgress(string progressText);
        string DecreaseProgress(string progressText);
    }
}