using UnityEngine;
using Levels;

namespace Enemy
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private float _Speed;

        private void Start()
        {
            _Speed = transform.parent.GetComponent<Way>().Speed;
            _speed = Random.Range(_Speed / 3, _Speed - 1);
        }

        private void Update()
        {
            Move();
            Delete();
        }

        private void Move()
        {
            transform.Translate(Vector3.back * _speed * Time.deltaTime);
        }

        private void Delete()
        {
            if (transform.position.y < -5f)
            {
                Destroy(gameObject);
            }
        }
    }
}
