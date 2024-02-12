using UnityEngine;
using Game;
using Levels;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player.Player player))
        {
            UnlockNewLevel();
            Way._isMoving = false;
        }
    }

    private void UnlockNewLevel()
    {
        if (PlayerPrefs.GetInt("UnlockedLevel",1) == LevelSelection.CurrentLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }   
    }
}
