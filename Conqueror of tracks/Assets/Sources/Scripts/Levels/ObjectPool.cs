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

        protected void ClearObject()
        {
            _pool.Clear();
            _currentIndexPool = 0;

            while (_container.transform.childCount > 0)
            {
                DestroyImmediate(_container.transform.GetChild(0).gameObject);
            }
        }

        protected bool TryGetFirstObject(out GameObject result)
        {
            result = _pool.Skip(_currentIndexPool).FirstOrDefault(p => !p.activeSelf);
            _currentIndexPool++;
            return result != null;
        }
    }
}
