using UnityEngine;

namespace Game
{
    public class DataHolder : MonoBehaviour, IController
    {
        [SerializeField] private float Speed;

        public float CurrentSpeed { get => Speed; set => value = Speed; }

        private void Awake()
        {
            CurrentSpeed = Speed;
        }
    }
}
