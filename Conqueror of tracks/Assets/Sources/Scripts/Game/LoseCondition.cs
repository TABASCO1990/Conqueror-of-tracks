using UnityEngine;
using Levels;

namespace Game
{
    public abstract class LoseCondition : MonoBehaviour
    {
        [SerializeField] protected bool IsRotate;

        protected Way way;

        protected abstract void Start();       

        public void StopPlay()
        {
            Way.IsMoving = false;
            way.DestroyCars();
        }
    }
}
