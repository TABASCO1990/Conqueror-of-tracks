using UnityEngine;

namespace Enemy
{
    public class CarTrucks : Car
    {
        protected override void Move()
        {
            transform.Translate(Vector3.back * _speed * Time.deltaTime);
        }
    }
}
