using TMPro;
using UnityEngine;
using Game;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private DataHolder _dataHolder;
    [SerializeField] private Text _points;
    [SerializeField] private Text _sumPoints;

    private void OnEnable()
    {
        OnShowPoints(); 
    }

    private void OnDisable()
    {
        OnShowPoints();
    }

    private void OnShowPoints()
    {
        _points.text = _dataHolder.CurrentPoints.ToString();
        _sumPoints.text = _dataHolder.SumCountPoints.ToString();      
    }
}
