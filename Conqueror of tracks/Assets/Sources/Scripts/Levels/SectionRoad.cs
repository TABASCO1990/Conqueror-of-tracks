using UnityEngine;
using Enemy;

namespace Level
{
    public class SectionRoad : MonoBehaviour
    {
        [SerializeField] private Car _car;
        [SerializeField] private float _offsetX;

        public float OffsetX => _offsetX;

        void Start()
        {
            SetCar();
        }

        private void SetCar()
        {     
            Instantiate(_car, new Vector3(_offsetX, 1f ,transform.position.z), Quaternion.identity, transform.parent.parent);
        }
    }
}
