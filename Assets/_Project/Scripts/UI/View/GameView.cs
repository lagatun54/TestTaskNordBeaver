using _Project.Scripts.UI.Entry;
using _Project.Scripts.UI.Interfaces;
using _Project.Scripts.UI.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private Button showButton;
        [SerializeField] private Button clearButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private Button increaseButton;
        [SerializeField] private Button decreaseButton;

        
        [SerializeField] private TMP_InputField inputField;              
        [SerializeField] private TextMeshProUGUI tmpText;              
        [SerializeField] private AdvancedDropdown advancedDropdown;
        [SerializeField] private Slider slider1;                      
        [SerializeField] private Slider slider2;
        [SerializeField] private Toggle checkbox;                     


        private IGameController controller;
        private GameConfig gameConfig;

        public void Initialize(IGameController controller, GameConfig config)
        {
            this.controller = controller;
            this.gameConfig = config;

            showButton.onClick.AddListener(SaveToModel);
            clearButton.onClick.AddListener(ClearUIFields);
            increaseButton.onClick.AddListener(OnIncreaseClicked);
            decreaseButton.onClick.AddListener(OnDecreaseClicked);
            
            RegisterValueChangeHandlers();
            RegisterLogButton(closeButton);
            
            SetAcceptState(false);
            LoadFromModel();
        }
        
        private void SetAcceptState(bool active)
        {
            showButton.interactable = active;
        }
        
        private void RegisterValueChangeHandlers()
        {
            if (inputField != null)
                inputField.onValueChanged.AddListener(_ => SetAcceptState(true));

            if (advancedDropdown != null)
                advancedDropdown.onChangedValue += _ => SetAcceptState(true);

            if (slider1 != null)
                slider1.onValueChanged.AddListener(_ => SetAcceptState(true));

            if (slider2 != null)
                slider2.onValueChanged.AddListener(_ => SetAcceptState(true));

            if (checkbox != null)
                checkbox.onValueChanged.AddListener(_ => SetAcceptState(true));
            
            if (increaseButton != null)
                increaseButton.onClick.AddListener(() => SetAcceptState(true));

            if (decreaseButton != null)
                decreaseButton.onClick.AddListener(() => SetAcceptState(true));
        }

        
        
        private void ClearUIFields()
        {
            if (inputField != null)
                inputField.text = "";

            if (tmpText != null)
                tmpText.text = "0/10";

            if (advancedDropdown != null)
                advancedDropdown.SetDefaultText();

            if (slider1 != null)
                slider1.value = slider1.minValue;

            if (slider2 != null)
                slider2.value = slider2.minValue;
            
            if (checkbox != null)
                checkbox.isOn = false;
            
            SetAcceptState(false);
        }
        private void SaveToModel()
        {
            gameConfig.inputText = inputField.text;
            gameConfig.dropdownValue = advancedDropdown.value;
            gameConfig.slider1Value = slider1.value;
            gameConfig.slider2Value = slider2.value * 25;
            gameConfig.checkboxValue = checkbox.isOn;
            SetAcceptState(false);

        }

        private void LoadFromModel()
        {
            inputField.text = gameConfig.inputText;
            tmpText.text = "0/10";

            if (gameConfig.dropdownValue >= 0)
                advancedDropdown.SelectOption(gameConfig.dropdownValue);
            else
                advancedDropdown.SetDefaultText();

            slider1.value = gameConfig.slider1Value;
            slider2.value = gameConfig.slider2Value;
            checkbox.isOn =  gameConfig.checkboxValue;
            
            SetAcceptState(false);
        }
        
        private void RegisterLogButton(Button button)
        {
            if (button != null)
            {
                button.onClick.AddListener(() => Debug.Log($"Button clicked: {button.name}"));
            }
        }
        
        private void OnIncreaseClicked()
        {
            var currentText = tmpText.text;
            var newText = controller.IncreaseProgress(currentText);
            tmpText.text = newText;
        }

        private void OnDecreaseClicked()
        {
            var currentText = tmpText.text;
            var newText = controller.DecreaseProgress(currentText);
            tmpText.text = newText;
        }
    }

}