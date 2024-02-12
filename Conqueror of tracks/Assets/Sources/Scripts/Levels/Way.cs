using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Game;

namespace Levels
{
    public class Way : ObjectPool
    {
        [SerializeField] private GameObject[] _roadsPrefabs;
        [SerializeField] private int _maxCountPrefabsOnWay;
        [SerializeField] private DataHolder _holer;

        private List<GameObject> _roads = new List<GameObject>();
        private Quaternion _rotationRoad;
        private int _currentTime;
        private int _currentRoadsCount;
        private float _speed;
        private float _distance;
        private float _distanceBetweenRoad;
        private float _zOffsetDeactivate = -30f;
        private float _zOffsetToMoveDown = -20f;

        public static bool _isMoving;

        public static event Action<float> ChengedDistance;

        private void OnEnable()
        {

            ResetRoad();
            InstanceRoad();
        }

        private void OnDisable()
        {
            StopCoroutine(ExecuteAfterTime());
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

        public void ResetRoad()
        {
            _speed = _holer.GetComponent<IController>().CurrentSpeed;
            _currentTime = 0;
            _currentRoadsCount = 0;
            _isMoving = true;
            StartCoroutine(ExecuteAfterTime());
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

        private IEnumerator ExecuteAfterTime()
        {
            while (_isMoving)
            {
                _distance = _speed * _currentTime;
                ChengedDistance?.Invoke(_distance);
                _currentTime++;
                yield return new WaitForSeconds(1);
            }
        }
    }
}