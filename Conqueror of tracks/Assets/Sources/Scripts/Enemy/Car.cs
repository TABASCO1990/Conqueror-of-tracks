using UnityEngine;
using Levels;

namespace Enemy
{
    public abstract class Car : MonoBehaviour
    {
        private float _SpeedRoad;

        public float Speed { get; set; }

        private void Start()
        {
            _SpeedRoad = transform.parent.GetComponent<Way>().Speed;
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
