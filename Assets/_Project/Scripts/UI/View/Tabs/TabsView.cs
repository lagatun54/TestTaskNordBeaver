using UnityEngine;
using UnityEngine.UI;

public class TabsView : MonoBehaviour
{
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;

    [SerializeField] private Canvas canvas1;
    [SerializeField] private Canvas canvas2;
    [SerializeField] private Canvas canvas3;

    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite activeSprite;

    public Button[] Buttons => new[] { button1, button2, button3 };
    public Canvas[] Canvases => new[] { canvas1, canvas2, canvas3 };

    public void SetActiveState(int index)
    {
        for (int i = 0; i < Canvases.Length; i++)
        {
            Canvases[i].enabled = (i == index);

            var image = Buttons[i].GetComponent<Image>();
            if (image != null)
                image.sprite = (i == index) ? activeSprite : normalSprite;
        }
    }
}