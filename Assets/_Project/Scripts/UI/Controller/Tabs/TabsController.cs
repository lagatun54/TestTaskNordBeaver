using UnityEngine;
using Zenject;

public class TabsController : IInitializable
{
    private readonly TabsView view;

    public TabsController(TabsView view)
    {
        this.view = view;
    }

    public void Initialize()
    {
        for (int i = 0; i < view.Buttons.Length; i++)
        {
            int index = i;
            view.Buttons[i].onClick.AddListener(() => OnTabClicked(index));
        }

        OnTabClicked(0); // по умолчанию включаем первый
    }

    private void OnTabClicked(int index)
    {
        view.SetActiveState(index);
    }
}