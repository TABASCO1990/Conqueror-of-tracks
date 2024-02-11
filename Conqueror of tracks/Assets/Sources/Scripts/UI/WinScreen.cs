using Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;

    private void OnEnable()
    {
        foreach (var gameObject in _gameObjects)
        {
            gameObject.SetActive(false);
        }
    }
}
