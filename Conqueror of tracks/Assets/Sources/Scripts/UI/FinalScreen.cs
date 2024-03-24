using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] private GameObject _pauseButton;

    private void OnEnable()
    {
        _pauseButton.GetComponent<Image>().enabled = false;
    }

    private void OnDisable()
    {
        _pauseButton.GetComponent<Image>().enabled = true;
    }
}
