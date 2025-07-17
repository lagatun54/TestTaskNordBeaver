using UnityEngine;
using Zenject;
class TabsInstaller : MonoInstaller
{
    [SerializeField] private TabsView tabsView;

    public override void InstallBindings()
    {
        Container.Bind<TabsView>().FromInstance(tabsView).AsSingle();
        Container.BindInterfacesTo<TabsController>().AsSingle(); // IInitializable
    }
}