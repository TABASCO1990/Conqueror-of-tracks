using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Levels
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _container;

        private List<GameObject> _pool = new List<GameObject>();
        private Vector3 _positionSpawn = new Vector3(0, 0, -20f);
        private int _currentIndexPool = 0;


        protected void Initialize(GameObject prefab, Quaternion rotation)
        {
            GameObject spawnedStart = Instantiate(prefab, _positionSpawn, rotation, _container.transform);
            spawnedStart.SetActive(false);
            _pool.Add(spawnedStart);
        }

        protected bool TryGetFirstObject(out GameObject result)
        {
            result = _pool.Skip(_currentIndexPool).FirstOrDefault(p => !p.activeSelf);
            _currentIndexPool++;

            return result != null;
        }
    }
}
