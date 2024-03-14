using TMPro;
using UnityEngine;
using Game;

public class Result : MonoBehaviour
{
    [SerializeField] private DataHolder _dataHolder;
    [SerializeField] private TMP_Text _points;
    [SerializeField] private TMP_Text _sumPoints;

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
