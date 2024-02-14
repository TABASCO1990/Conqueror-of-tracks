using UnityEngine;
using Levels;

namespace Obstacle
{
    public class Hole : MonoBehaviour
    {
        private Way way;

        private void Start()
        {
            way = transform.parent.parent.GetComponent<Way>();
        }

        public void StopPlay()
        {
            way.Speed = 0;
            way.DestroyCars();
        }
    }
}
