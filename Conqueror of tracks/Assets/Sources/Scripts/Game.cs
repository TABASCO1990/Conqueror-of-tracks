using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private LevelScreen _levelScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _levelScreen.MenuButtonClick += OnMenuButtonClick;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _levelScreen.MenuButtonClick -= OnMenuButtonClick;
    }

    private void Start()
    {
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        _levelScreen.Open();
    }

    private void OnMenuButtonClick()
    {
        _levelScreen.Close();
        _startScreen.Open();
    }


}
