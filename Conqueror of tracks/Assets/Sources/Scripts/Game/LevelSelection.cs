using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Game
{
    public class LevelSelection : MonoBehaviour
    {
        public static int CurrentLevel;

        [SerializeField] private GameObject _levelButtons;
        [SerializeField] private GameObject _pauseButton;
        [SerializeField] private GameObject _infomationBoard;
        [SerializeField] private GameObject _sceenGameIsOver;
        [SerializeField] private GameObject _soundButton;

        private int _countUnlockedLevel;
        private Button[] _buttons;

        public event Action<GameObject> SettledLevel;

        private void OnEnable()
        {
            AddButtonsLevel();
            PlayerLoadYG();

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

        private void OnDisable() => YandexGame.GetDataEvent -= PlayerLoadYG;

        public void Initiate(GameObject map)
        {
            gameObject.SetActive(false);
            map.SetActive(true);
            _pauseButton.SetActive(true);
            _soundButton.SetActive(true);
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
      
        private void PlayerLoadYG()
        {
            _countUnlockedLevel = YandexGame.savesData.curentLevel;
        }       
    }
}
