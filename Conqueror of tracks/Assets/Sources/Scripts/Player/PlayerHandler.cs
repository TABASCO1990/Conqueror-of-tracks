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
                SetAnimationEnemy(car);
                SetAnimationPlayer();
                Destroy(car.gameObject,1f);
            }
        }

        private void SetAnimationPlayer()
        {
            transform.DOMoveZ(transform.position.z - 4f, 1f).SetLink(gameObject);
            transform.DORotate(new Vector3(5f, transform.position.y, transform.position.z), 0.1f).SetLoops(2, LoopType.Yoyo).SetLink(gameObject);
        }

        private void SetAnimationEnemy(Car car)
        {
            car.GetComponent<BoxCollider>().enabled = false;
            car.transform.DORotate(new Vector3(Random.Range(20, 50), Random.Range(20, 50), Random.Range(20, 50)), 0.5f).SetLink(gameObject);
        }
    }
}
