using Levels;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private Way _way;
    

    public void Reload()
    { 

        Way.instance.gameObject.SetActive(false);
        _pauseScreen.SetActive(false);
        Way.instance.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void Home()
    {
        Way.instance.gameObject.SetActive(false);
        Time.timeScale = 1;
        _pauseScreen.SetActive(false);
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
}
