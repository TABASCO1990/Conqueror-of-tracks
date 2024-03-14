using UnityEngine;
using Game;
using TMPro;

namespace UI
{
    public class Speed : MonoBehaviour
    {
        [SerializeField] private DataHolder _dataHolder;
        [SerializeField] private TMP_Text _textSpeed;

        private void OnEnable()
        {
            _dataHolder.SetedSpeed += OnSetedSpeed;
        }

        private void OnDisable()
        {
            _dataHolder.SetedSpeed -= OnSetedSpeed;
        }

        private void OnSetedSpeed(float value)
        {
            _textSpeed.text = value + " mph";
        }
    }
}
