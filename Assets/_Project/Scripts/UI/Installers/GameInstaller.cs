using _Project.Scripts.Core.Services;
using _Project.Scripts.UI.Controller;
using _Project.Scripts.UI.Entry;
using _Project.Scripts.UI.Interfaces;
using UnityEngine;
using Zenject;


namespace _Project.Scripts.UI.Installers
{
    
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameView gameView;
        [SerializeField] private GameConfig gameConfig;

        public override void InstallBindings()
        {
            Container.Bind<IGameView>().FromInstance(gameView).AsSingle();
            Container.Bind<IProgressService>().To<ProgressService>().AsSingle();
            Container.Bind<IGameController>().To<GameController>().AsSingle();

            Container.Bind<GameConfig>().FromInstance(gameConfig).AsSingle();
            Container.BindInterfacesTo<StartupLinker>().AsSingle();
        }
    }
}