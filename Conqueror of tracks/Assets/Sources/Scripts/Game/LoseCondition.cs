using UnityEngine;
using Levels;
using YG;

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
            YandexGame.FullscreenShow();
        }
    }
}
