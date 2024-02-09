using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected GameObject GameObject;
    [SerializeField] protected Button Button;

    public event Action PlayButtonClick;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);
    }
    public void Open()
    {
        GameObject.SetActive(true);
    }

    public void Close()
    {
        GameObject.SetActive(false);
    }

    public abstract void OnButtonClick();
}
