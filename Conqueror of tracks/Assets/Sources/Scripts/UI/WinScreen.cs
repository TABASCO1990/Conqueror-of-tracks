using UnityEngine;

namespace UI
{
    public class WinScreen : MonoBehaviour
    {
        [SerializeField] private GameObject[] _gameObjects;

        private void OnEnable()
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.SetActive(false);
            }
        }
    }
}