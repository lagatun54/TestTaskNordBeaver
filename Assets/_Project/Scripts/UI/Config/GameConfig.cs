using UnityEngine;

namespace _Project.Scripts.UI.Entry
{

    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        public string inputText = "";
        public int stepper = 0;
        public int dropdownValue = -1;
        public float slider1Value = 0;
        public float slider2Value = 0;
        public bool checkboxValue = false;
    }
}