using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Levels
{
    public class Way : ObjectPool
    {
        [SerializeField] private GameObject[] _roadsPrefabs;
        [SerializeField] private float _speed;
        [SerializeField] private int _maxCountPrefabsOnWay = 5;

        private Quaternion _rotationRoad;
        private float _distanceBetweenRoad;
        private List<GameObject> _roads = new List<GameObject>();
        private int _currentRoadsCount;
        private float _zOffsetDeactivate = -30f;
        private float _zOffsetToMoveDown = -20f;
        private bool _isMoving;

        public static Way instance = null;

        private void OnEnable()
        {
            ResetRoad();
            InstanceRoad();
        }

        private void OnDisable()
        {
            ResetRoad();
        }

        void Start()
        {
            
        }
        private void Update()
        {
            if (_isMoving)
            {
                Move();

                if (_currentRoadsCount == _maxCountPrefabsOnWay)
                {
                    ActivateRoad();
                }

                DeactivateRoad();
            }
        }

        private void Move()
        {
            foreach (var road in _roads)
            {
                road.transform.Translate(Vector3.back * _speed * Time.deltaTime, Space.World);

                if (road.transform.localPosition.z < _zOffsetToMoveDown)
                {
                    road.transform.Translate(Vector3.down * _speed / 2 * Time.deltaTime, Space.World);
                }
            }
        }

        private void ActivateRoad()
        {
            if (_roads.Count > 0)
            {
                if (TryGetFirstObject(out GameObject road))
                {
                    SetRoad(road, _roads[_roads.Count - 1].transform.position.z + _distanceBetweenRoad);
                }
            }
            else if (_roads.Count == 0)
            {
                if (TryGetFirstObject(out GameObject road))
                {
                    SetRoad(road, road.transform.position.z);
                }
            }
        }

        private void DeactivateRoad()
        {
            if (_currentRoadsCount > 0 && _roads[0].transform.localPosition.z < _zOffsetDeactivate)
            {
                _roads[0].SetActive(false);
                _roads.RemoveAt(0);
                _currentRoadsCount--;
                _isMoving = _currentRoadsCount > 0;
            }
        }

        private void SetRoad(GameObject road, float spawnPointsZ)
        {
            road.SetActive(true);
            road.transform.position = new Vector3(road.transform.position.x, road.transform.position.y, spawnPointsZ);
            _roads.Add(road);
            _currentRoadsCount++;

            if (_roadsPrefabs.Length > _maxCountPrefabsOnWay)
            {
                road.transform.DORotate(new Vector3(0, 0, 0), 0.5f);
            }
        }

        private void InstanceRoad()
        {
            _rotationRoad = Quaternion.Euler(45, 0, 0);
            _distanceBetweenRoad = _roadsPrefabs[0].transform.GetChild(0).GetComponent<Renderer>().bounds.size.z;

            for (int i = 0; i < _roadsPrefabs.Length; i++)
            {
                Quaternion rotation = (i < _maxCountPrefabsOnWay) ? Quaternion.identity : _rotationRoad;
                Initialize(_roadsPrefabs[i], rotation);
            }
            for (int i = 0; i < _maxCountPrefabsOnWay; i++)
            {
                ActivateRoad();
            }
        }

        public void ResetRoad()
        {
            _isMoving = true;
            _currentRoadsCount = 0;
            ClearObject();
            _roads.Clear();
        }
    }
}