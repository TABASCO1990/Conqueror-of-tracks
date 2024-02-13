using UnityEngine;

namespace Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private LevelSelection _levelSelection;
        [SerializeField] private GameObject _currentLevel;
        [SerializeField] private GameObject _pauseScreen;
        [SerializeField] private GameObject _winScreen;
        [SerializeField] private GameObject _InfomationBoard;
        [SerializeField] private Player.Player _player;

        private void OnEnable()
        {
            _levelSelection.SettledLevel += OnSettledLevel;
        }

        private void OnDisable()
        {
            _levelSelection.SettledLevel -= OnSettledLevel;
        }

        public void ReloadInPauseSceen()
        {
            _currentLevel.SetActive(false);
            _pauseScreen.SetActive(false);
            _currentLevel.SetActive(true);
            _player.transform.localPosition = Vector3.zero;
            Time.timeScale = 1;
        }

        public void ReloadInWinScreen()
        {
            _currentLevel.SetActive(false);
            _InfomationBoard.SetActive(true);
            _winScreen.SetActive(false);
            _currentLevel.SetActive(true);
            _player.transform.localPosition = Vector3.zero;
        }

        public void Home()
        {
            _currentLevel.SetActive(false);
            Time.timeScale = 1;
            _pauseScreen.SetActive(false);
            _player.transform.localPosition = Vector3.zero;
        }

        public void Resume()
        {
            _pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void NexLevel()
        {
            _currentLevel.SetActive(false);
            _levelSelection.SetLevel();
            _player.transform.localPosition = Vector3.zero;
        }

        private void OnSettledLevel(GameObject map)
        {
            _currentLevel = map;
        }
    }
}
