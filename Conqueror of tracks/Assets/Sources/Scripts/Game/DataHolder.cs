using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YG;

namespace Game
{
    public class DataHolder : MonoBehaviour, IController
    {
        public List<int> _scores = new List<int>();
        private int _countLevels = 18;
        private int _sumCountPoints;

        public float CurrentSpeed { get; set; }
        public int CurrentPoints { get; set; }
        public int SumCountPoints => _sumCountPoints;

        public event Action<int> AddingCoins;
        public event Action<float> SetedSpeed;

        private void Start()
        {
            LoadPoints();

            if (YandexGame.SDKEnabled == true)
            {
                PlayerLoadYG();
                print("Яндекс сохранения");
            }
            /*else
            {
                _sumCountPoints = PlayerPrefs.GetInt("SumScores");
                print("PlayerPrefs сохранения");
            }*/
        }

        public void AddCoins()
        {
            CurrentPoints++;
            AddingCoins?.Invoke(CurrentPoints);
        }

        public void SetSpeed()
        {
            SetedSpeed?.Invoke(CurrentSpeed);
        }

        public void SavePoints()
        {
            _scores[LevelSelection.CurrentLevel - 1] = CurrentPoints;
            PlayerPrefs.SetInt("Scores" + (LevelSelection.CurrentLevel - 1), CurrentPoints);

            _sumCountPoints = _scores.Sum();
            //PlayerPrefs.SetInt("SumScores", _sumCountPoints);

            PlayerSaveYG();

            YandexGame.FullscreenShow();
        }

        private void LoadPoints()
        {
            _scores.Clear();

            for (int i = 0; i < _countLevels; i++)
            {
                int point = PlayerPrefs.GetInt("Scores" + i);
                //int point = YandexGame.savesData.scores[i];
                _scores.Add(point);
            }
        }

        private void PlayerSaveYG()
        {
            YandexGame.savesData.points = _sumCountPoints;          
            YandexGame.SaveProgress();
        }

        private void PlayerLoadYG()
        {
            _sumCountPoints = YandexGame.savesData.points;
        }

        private void OnEnable() => YandexGame.GetDataEvent += PlayerLoadYG;

        private void OnDisable() => YandexGame.GetDataEvent -= PlayerLoadYG;
    }
}
