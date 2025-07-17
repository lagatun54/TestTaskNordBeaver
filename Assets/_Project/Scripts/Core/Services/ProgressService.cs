using System;
using _Project.Scripts.UI.Interfaces;

namespace _Project.Scripts.Core.Services
{
    public class ProgressService : IProgressService
    {
        private const int DefaultMax = 10;

        public int GetCurrent(string progressText)
        {
            if (string.IsNullOrEmpty(progressText)) return 0;

            var parts = progressText.Split('/');
            return int.TryParse(parts[0], out int value) ? value : 0;
        }

        public string SetCurrent(int newValue)
        {
            int clamped = Math.Clamp(newValue, 0, DefaultMax);
            return $"{clamped}/{DefaultMax}";
        }
        
        public string Increase(string progressText)
        {
            int current = GetCurrent(progressText);
            return SetCurrent(current + 1);
        }

        public string Decrease(string progressText)
        {
            int current = GetCurrent(progressText);
            return SetCurrent(current - 1);
        }
    }
}