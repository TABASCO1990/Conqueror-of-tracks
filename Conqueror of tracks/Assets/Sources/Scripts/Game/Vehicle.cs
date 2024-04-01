using UnityEngine;
using UnityEngine.UI;
using Game;
using YG;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private DataHolder _dataHolder;
    [SerializeField] private Button _button;
    [SerializeField] private int _index;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnSetVehicle);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnSetVehicle);
    }

    private void OnSetVehicle()
    {
        for (int i = 0; i < _dataHolder.Vehicles.Length; i++)
        {
            if(i == _index)
            {
                _dataHolder.Vehicles[i].SetActive(true);
                YandexGame.savesData.CurrentIndexVehicles = _index;
                YandexGame.SaveProgress();
            }
            else
            {
                _dataHolder.Vehicles[i].SetActive(false);
            }
        }
    }
}
