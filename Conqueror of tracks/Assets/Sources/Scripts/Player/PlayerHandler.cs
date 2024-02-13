using UnityEngine;
using Game;
using Enemy;
using DG.Tweening;

namespace Player
{
    public class PlayerHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _winScreen;
        [SerializeField] private DataHolder _dataHolder;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out FinishPoint finishPoint))
            {
                _winScreen.SetActive(true);
            }
            else if(other.TryGetComponent(out Coin coin))
            {
                _dataHolder.AddCoins();
                Destroy(coin.gameObject);
            }
            else if(other.TryGetComponent(out Car car))
            {
                transform.DORotate(new Vector3(8, transform.position.y, transform.position.z), 0.2f).SetLoops(2,LoopType.Yoyo);
                // Плавно переместить назад
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-10);
                car.transform.DORotate(new Vector3(Random.Range(20,50), Random.Range(20, 50), Random.Range(20, 50)), 0.5f);
                Destroy(car.gameObject,1f);

            }
        }
    }
}
