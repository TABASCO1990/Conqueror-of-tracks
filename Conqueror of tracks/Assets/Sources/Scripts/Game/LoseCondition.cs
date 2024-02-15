using UnityEngine;
using Levels;

namespace Game
{
    public abstract class LoseCondition : MonoBehaviour
    {
        protected Way way;

        protected abstract void Start();       

        public void StopPlay()
        {
            Way.IsMoving = false;
            way.DestroyCars();
        }
    }
}
