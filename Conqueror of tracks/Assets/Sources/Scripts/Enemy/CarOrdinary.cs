using UnityEngine;

namespace Enemy
{
    public class CarOrdinary : Car
    {
        protected override void Move()
        {
            transform.Translate(Vector3.back * _speed * Time.deltaTime);
        }
    }
}
