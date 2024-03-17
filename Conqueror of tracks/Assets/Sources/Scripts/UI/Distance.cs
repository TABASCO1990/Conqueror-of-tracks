using Levels;
using UnityEngine;
using TMPro;

namespace UI
{
    public class Distance : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textDistance;

        private void OnEnable()
        {
            Way.ChengedDistance += OnChangedDistance;
        }

        private void OnDisable()
        {
            Way.ChengedDistance += OnChangedDistance;
        }

        private void OnChangedDistance(float distance)
        {
            _textDistance.text = distance.ToString();
        }
    }
}
