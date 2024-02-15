using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Enemy;
using Game;

namespace Levels
{
    public class Way : ObjectPool
    {
        public static bool IsMoving;

        [SerializeField] private GameObject[] _roadsPrefabs;
        [SerializeField] private DataHolder _holder;
        [SerializeField] private GameObject _pointDead;
        [SerializeField] private int _maxCountPrefabsOnWay;
        [SerializeField] private float _speed;

        private List<GameObject> _roads = new List<GameObject>();
        private Quaternion _rotationRoad;
        private int _currentTime;
        private int _currentRoadsCount;
        private float _distance;
        private float _distanceBetweenRoad;
        private float _zOffsetDeactivate = -30f;
        private float _zOffsetToMoveDown = -20f;

        public static event Action<float> ChengedDistance;

        public float Speed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = value;
            }
        }

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

        public void DestroyCars()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<Car>())
                    Destroy(transform.GetChild(i).gameObject);
                else if (transform.GetChild(i).GetComponent<PointDead>())
                    Destroy(transform.GetChild(i).gameObject);
            }
        }

        public void ResetRoad()
        {
            DOTween.KillAll();
            DestroyCars();
            Destroy(_pointDead);
            _holder.CurrentSpeed = _speed;
            _holder.CurrentCoins = -1;
            _currentTime = 0;
            _currentRoadsCount = 0;
            IsMoving = true;
            StartCoroutine(ExecuteAfterTime());
            _holder.AddCoins();
            _holder.SetSpeed();
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
            SetPointDed();


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

        private void SetPointDed()
        {
            Vector3 positionPointDead = new Vector3(0, 0, _zOffsetToMoveDown + _distanceBetweenRoad / 2);
            Instantiate(_pointDead, positionPointDead, Quaternion.identity, this.transform);
        }

        private IEnumerator ExecuteAfterTime()
        {
            while (IsMoving)
            {
                _distance = _speed * _currentTime;
                ChengedDistance?.Invoke(_distance);
                _currentTime++;
                yield return new WaitForSeconds(1);
            }
        }
    }
}