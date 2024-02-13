using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class IndexButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private int _index;

        public int Index => _index;

        public void OnPointerClick(PointerEventData eventData)
        {
            LevelSelection.CurrentLevel = _index;
        }
    }
}
