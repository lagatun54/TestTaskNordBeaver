namespace _Project.Scripts.UI.Interfaces
{
    public interface IProgressService
    {
        int GetCurrent(string progressText);
        string SetCurrent(int newValue);
        
        string Increase(string progressText);
        string Decrease(string progressText);
    }
}