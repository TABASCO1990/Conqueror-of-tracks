using Game;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private DataHolder _dataHolder;
        [SerializeField] private TMP_Text _textCoins;

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
            _textCoins.text = value + " coins";
        }
    }
}
