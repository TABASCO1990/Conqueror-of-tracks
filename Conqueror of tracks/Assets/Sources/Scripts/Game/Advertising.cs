using Game;
using UnityEngine;
using YG;

public class Advertising : MonoBehaviour
{
    [SerializeField] private DataHolder _dataHolder;
    [SerializeField] private Result _result;

    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    void Rewarded(int id)
    {
        if (id == 1)
            AddPoints();

        else if (id == 2)
            AddCar();
    }

    private void AddPoints()
    {
        _dataHolder.CurrentPoints *= 2;
        _dataHolder.SavePoints();
        _result.OnShowPoints();
    }

    private void AddCar()
    {
        _dataHolder.SetVehicles();
    }

    public void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
}
