using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player.Player player))
        {
            print(PlayerPrefs.GetInt("UnlockedLevel"));
            UnlockNewLevel();
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
