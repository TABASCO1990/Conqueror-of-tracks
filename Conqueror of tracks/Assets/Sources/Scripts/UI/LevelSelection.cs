using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public static int CurrentLevel;

    [SerializeField] private GameObject _levelButtons;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _infomationBoard;
    
    private int _countUnlockedLevel;
    private Button[] _buttons;

    private void OnEnable()
    {
        AddButtonsLevel();

        _countUnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        foreach (var button in _buttons)
        {
            button.interactable = false;
        }

        for (int i = 0; i < _countUnlockedLevel; i++)
        {
            _buttons[i].interactable = true;
        }
    }

    public void Initiate(GameObject map)
    { 
        gameObject.SetActive(false);
        map.SetActive(true);
        _pauseButton.SetActive(true);
        _infomationBoard.SetActive(true);
    }

    private void AddButtonsLevel()
    {
        int childCount = _levelButtons.transform.childCount;
        _buttons = new Button[childCount];

        for (int i = 0; i < childCount; i++)
        {
            _buttons[i] = _levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
}
