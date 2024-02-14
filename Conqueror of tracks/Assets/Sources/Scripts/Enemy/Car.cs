using UnityEngine;
using Levels;

namespace Enemy
{
    public abstract class Car : MonoBehaviour
    {
        [SerializeField] protected float _speed;

        private float _SpeedRoad;

        private void Start()
        {
            _SpeedRoad = transform.parent.GetComponent<Way>().Speed;
            _speed = Random.Range(_SpeedRoad / 3, _SpeedRoad - 1);
        }

        private void Update()
        {
            Move();
            Delete();
        }

        protected abstract void Move();

        private void Delete()
        {
            if (transform.position.y < -5f)
            {
                Destroy(gameObject);
            }
        }
    }
}
