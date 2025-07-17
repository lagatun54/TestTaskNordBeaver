using System;
using _Project.Scripts.UI;
using _Project.Scripts.UI.Entry;
using _Project.Scripts.UI.Interfaces;
using _Project.Scripts.UI.Model;
using Zenject;

namespace _Project.Scripts
{
    public class StartupLinker : IInitializable
    {
        private readonly IGameView view;
        private readonly IGameController controller;
        private readonly GameConfig config;

        public StartupLinker(IGameView view, IGameController controller, GameConfig config)
        {
            this.view = view;
            this.controller = controller;
            this.config = config;
        }

        public void Initialize()
        {
            if (view is GameView realView)
                realView.Initialize(controller, config);
        }
    }
}