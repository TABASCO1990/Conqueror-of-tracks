using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class LevelSelection : MonoBehaviour
    {
        public static int CurrentLevel;

        [SerializeField] private GameObject _levelButtons;
        [SerializeField] private GameObject _pauseButton;
        [SerializeField] private GameObject _infomationBoard;
        [SerializeField] private GameObject _sceenGameIsOver;

        private int _countUnlockedLevel;
        private Button[] _buttons;

        public event Action<GameObject> SettledLevel;

        private void OnEnable()
        {
            AddButtonsLevel();
            _countUnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

            foreach (var button in _buttons)
            {
                button.interactable = false;
            }

            for (int i = 0; i < _countUnlockedLevel; i++)
            {
                if (_countUnlockedLevel <= _buttons.Length)
                {
                    _buttons[i].interactable = true;
                }
            }       
        }

        public void Initiate(GameObject map)
        {
            gameObject.SetActive(false);
            map.SetActive(true);
            _pauseButton.SetActive(true);
            _infomationBoard.SetActive(true);
            SettledLevel?.Invoke(map);
        }

        public void SetLevel()
        {
            CurrentLevel++;
            if (CurrentLevel <= _buttons.Length)
            {
                _buttons[CurrentLevel - 1].interactable = true;
                _buttons[CurrentLevel - 1].onClick.Invoke();
            }
            else
            {
                _sceenGameIsOver.SetActive(true);
            }
        }

        private void AddButtonsLevel()
        {
            int childCount = _levelButtons.transform.childCount;
            _buttons = new Button[childCount];

            for (int i = 0; i < childCount; i++)
            {
                _buttons[i] = _levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
            }
        }
    }
}
