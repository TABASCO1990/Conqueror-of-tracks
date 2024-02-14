using UnityEngine;
using Game;
using Enemy;
using DG.Tweening;
using Obstacle;

namespace Player
{
    public class PlayerHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _winScreen;
        [SerializeField] private GameObject _loseScreen;
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
                SetAnimationCrashEnemy(car);
                SetAnimationCrashPlayer();
                Destroy(car.gameObject,1f);
            }
            else if (other.TryGetComponent(out Hole hole))
            {
                transform.DOMoveY(-1.54f, 0.1f);
                transform.DORotate(new Vector3(15, transform.position.y, Random.Range(-10, 10)), 0.1f).SetLoops(2, LoopType.Yoyo).OnComplete(hole.StopPlay);
                _loseScreen.SetActive(true);
            }
        }

        private void SetAnimationCrashPlayer()
        {
            transform.DOMoveZ(transform.position.z - 4f, 1f).SetLink(gameObject);
            transform.DORotate(new Vector3(5f, transform.position.y, transform.position.z), 0.1f).SetLoops(2, LoopType.Yoyo).SetLink(gameObject);
        }

        private void SetAnimationCrashEnemy(Car car)
        {
            car.GetComponent<BoxCollider>().enabled = false;
            car.transform.DOMoveY(2, 0.5f);
            car.transform.DORotate(new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50)), 0.5f).SetLink(gameObject);
        }
    }
}
