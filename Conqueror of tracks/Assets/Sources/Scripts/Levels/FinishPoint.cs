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
        print("CurrentLevel: " + LevelSelection.CurrentLevel);
        print("YandexGame.savesData.curentLevel: " + YandexGame.savesData.curentLevel);

        if (YandexGame.savesData.curentLevel-1 == LevelSelection.CurrentLevel)
        {
            YandexGame.savesData.curentLevel = YandexGame.savesData.curentLevel + 1;
            YandexGame.SaveProgress();
        }
        /*
        if (PlayerPrefs.GetInt("UnlockedLevel",1) == LevelSelection.CurrentLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);            
            PlayerPrefs.Save();
        }*/
        

    }
}
