using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsCarPolice : MonoBehaviour
{
    [SerializeField] private Material _materialRed;
    [SerializeField] private Material _materialBlue;

    private void OnEnable()
    {
        _materialRed.color = Color.red;
        _materialBlue.color = Color.blue;
        SetAnimation();
    }

    private void OnDisable()
    {
        SetDefaultMaterial();
    }

    private void SetAnimation()
    {
        if (transform != null)
        {
            _materialRed.DOColor(Color.white, 0.11f).SetLoops(-1, LoopType.Yoyo).SetLink(gameObject);
            _materialBlue.DOColor(Color.white, 0.1f).SetLoops(-1, LoopType.Yoyo).SetLink(gameObject);
        }
        else
            SetDefaultMaterial();
    }

    private void SetDefaultMaterial()
    {
        _materialRed.color = Color.red;
        _materialBlue.color = Color.blue;
    }
}
