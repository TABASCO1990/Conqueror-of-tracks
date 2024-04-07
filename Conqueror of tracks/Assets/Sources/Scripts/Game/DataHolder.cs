using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using YG;
using YG.Utils.LB;

namespace Game
{
    public class DataHolder : MonoBehaviour, IController
    {
        [SerializeField] private LeaderboardYG _leaderboardYG;
        [SerializeField] private Text _rank;
        [SerializeField] private Text _rankStart;
        [SerializeField] private Text _nameBestPlayer;
        [SerializeField] private GameObject[] _vehicles;

        private int _countLevels = 18;
        private int _sumCountPoints;
        private int _curentIndexVehicles;

        public List<int> _scores = new List<int>();

        public float CurrentSpeed { get; set; }
        public int CurrentPoints { get; set; }
        public int SumCountPoints => _sumCountPoints;
        public GameObject[] Vehicles => _vehicles;

        public event Action<int> AddingCoins;
        public event Action<float> SetedSpeed;

        private void OnEnable() => YandexGame.GetDataEvent += PlayerLoadYG;

        private void OnDisable() => YandexGame.GetDataEvent -= PlayerLoadYG;

        private void Start()
        {
            PlayerLoadYG();
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
            SetPlayerRank();
            _scores[LevelSelection.CurrentLevel - 1] = CurrentPoints;
            _sumCountPoints = _scores.Sum();
            PlayerSaveYG();
            YandexGame.FullscreenShow();
        }

        private void SetPlayerRank()
        {
            YandexGame.GetLeaderboard(nameLB: "LeaderPoints", maxQuantityPlayers: 10, quantityTop: 3, quantityAround: 3, photoSizeLB: "small");
            YandexGame.onGetLeaderboard += OnGetLeaderboard;
        }

        private void OnGetLeaderboard(LBData data)
        {
            _rank.text = data.thisPlayer.rank.ToString();
            _rankStart.text = data.thisPlayer.rank.ToString();

            if (YandexGame.initializedLB)
            {
                _nameBestPlayer.text = data.players[0].name.ToString();
            }
        }

        public void SetVehicles()
        {
            _curentIndexVehicles = YandexGame.savesData.CurrentIndexVehicles;
            _vehicles[_curentIndexVehicles].SetActive(true);
        }

        private void LoadPoints()
        {
            _scores.Clear();

            for (int i = 0; i < _countLevels; i++)
            {
                int point = YandexGame.savesData.scores[i];
                _scores.Add(point);
            }
        }

        private void PlayerSaveYG()
        {
            YandexGame.NewLeaderboardScores("LeaderPoints", _sumCountPoints);
            _leaderboardYG.NewScore(_sumCountPoints);
            _leaderboardYG.UpdateLB();
            YandexGame.savesData.scores[LevelSelection.CurrentLevel - 1] = CurrentPoints;
            YandexGame.savesData.points = _sumCountPoints;
            YandexGame.SaveProgress();
        }

        private void PlayerLoadYG()
        {
            SetPlayerRank();
            LoadPoints();
            _sumCountPoints = YandexGame.savesData.points;
            SetVehicles();         
        }
    }
}
