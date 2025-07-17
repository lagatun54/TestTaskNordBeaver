using _Project.Scripts.Core.Services;
using _Project.Scripts.UI.Entry;
using _Project.Scripts.UI.Interfaces;
using _Project.Scripts.UI.Model;
using UnityEngine;

namespace _Project.Scripts.UI.Controller
{
    public class GameController : IGameController
    {
        private readonly IProgressService progressService;

        private readonly GameConfig config;
        private GameData data = new GameData();
        

        public GameController(GameConfig config, IProgressService progressService)
        {
            this.config = config;
            this.progressService = progressService;

            ResetForm();
        }

        public void AcceptForm(GameData data)
        {
            var current = progressService.GetCurrent(data.inputText);
            var updated = progressService.SetCurrent(current + 1);
            data.inputText = updated;

            this.data = data;
        }

        public GameData GetForm()
        {
            return data;
        }

        public void ResetForm()
        {
            data.inputText = config.inputText;
            data.stepper = config.stepper;
            data.dropdownValue = config.dropdownValue;
            data.slider1Value = config.slider1Value;
            data.slider2Value = config.slider2Value;
            data.checkboxValue = config.checkboxValue;
        }
        
        public string IncreaseProgress(string progressText)
        {
            return progressService.Increase(progressText);
        }

        public string DecreaseProgress(string progressText)
        {
            return progressService.Decrease(progressText);
        }
    }


}