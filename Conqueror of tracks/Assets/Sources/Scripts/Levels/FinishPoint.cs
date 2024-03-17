using UnityEngine;
using Game;
using Levels;
using YG;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player.Player player))
        {
            UnlockNewLevel();
            Way.IsMoving = false;
        }
    }

    private void UnlockNewLevel()
    {
        if (YandexGame.savesData.curentLevel == LevelSelection.CurrentLevel)
        {
            YandexGame.savesData.curentLevel = YandexGame.savesData.curentLevel + 1;
            YandexGame.SaveProgress();
        }
    }
}
