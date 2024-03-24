using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

namespace Levels
{
    public class MainWay : ObjectPool
    {
        public static bool IsMoving;

        [SerializeField] private GameObject[] _roadsPrefabs;
        [SerializeField] private int _maxCountPrefabsOnWay;
        [SerializeField] private float _speed;

        private List<GameObject> _roads = new List<GameObject>();
        private Quaternion _rotationRoad;
        private int _currentRoadsCount;
        private float _distanceBetweenRoad;
        private float _zOffsetDeactivate = -33f;
        private float _zOffsetToMoveDown = -20f;

        private void OnEnable()
        {
            ResetRoad();
            InstanceRoad();
        }

        private void Update()
        {
            if (IsMoving)
            {
                Move();

                if (_currentRoadsCount == _maxCountPrefabsOnWay)
                {
                    ActivateRoad();
                }

                DeactivateRoad();
            }
        }

        public void ResetRoad()
        {
            DOTween.KillAll();
            _currentRoadsCount = 0;
            IsMoving = true;
            ClearObject();
            _roads.Clear();
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
                if (TryGetObjectFree(out GameObject road))
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
            if (_roads[0].transform.localPosition.z < _zOffsetDeactivate)
            {
                _roads[0].SetActive(false);
                _roads[0].transform.rotation = _rotationRoad;
                _roads.RemoveAt(0);
                _currentRoadsCount--;
            }
        }

        private void SetRoad(GameObject road, float spawnPointsZ)
        {
            road.SetActive(true);
            road.transform.position = new Vector3(0, 0, spawnPointsZ);

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
    }
}