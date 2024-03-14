using Game;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Points : MonoBehaviour
    {
        [SerializeField] private DataHolder _dataHolder;
        [SerializeField] private TMP_Text _textPoints;

        private void OnEnable()
        {
            _dataHolder.AddingCoins += OnAddedCoins;
        }

        private void OnDisable()
        {
            _dataHolder.AddingCoins -= OnAddedCoins;
        }

        private void OnAddedCoins(int value)
        {
            _textPoints.text = value + " points";
        }
    }
}
