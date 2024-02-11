using UnityEngine;

namespace Player
{
    public class PlayerHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _winScreen;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out FinishPoint finishPoint))
            {
                print("Ok");
                _winScreen.SetActive(true);
            }
        }
    }
}
