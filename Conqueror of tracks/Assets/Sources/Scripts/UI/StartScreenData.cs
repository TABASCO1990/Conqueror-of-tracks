using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;
using YG.Utils.LB;

public class StartScreenData : MonoBehaviour
{
    [SerializeField] private Text _rank;

    private void Awake()
    {
        YandexGame.GetLeaderboard(nameLB: "LeaderPoints", maxQuantityPlayers: 10, quantityTop: 3, quantityAround: 3, photoSizeLB: "small");
    }

    private void OnEnable()
    {
        YandexGame.onGetLeaderboard += OnGetLeaderboard;
    }

    private void OnDisable()
    {
        YandexGame.onGetLeaderboard -= OnGetLeaderboard;
    }

    private void OnGetLeaderboard(LBData data)
    {
        _rank.text = data.thisPlayer.rank.ToString();
    }
}
