using UnityEngine;
using Game;
using TMPro;

namespace UI
{
    public class Speed : MonoBehaviour
    {
        [SerializeField] private TMP_Text _speedText;
        [SerializeField] private DataHolder _dataHolder;

        private void OnEnable()
        {
            _speedText.text = _dataHolder.GetComponent<IController>().CurrentSpeed + " mhp";
        }
    }
}
