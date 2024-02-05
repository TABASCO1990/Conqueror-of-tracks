using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Way : ObjectPool
{
    [SerializeField] private GameObject[] _roadsPrefabs;
    [SerializeField] private float _speed;
    [SerializeField] private int _maxCountPrefabsOnWay = 5;

    private List<GameObject> _roads = new List<GameObject>();
    private float _distanceBetweenRoad;
    private int _currentRoadsCount;
    private float _zPositionToDeactivate = -25f;
    private float _endValueMoveDownY = -10f;
    private float _durationMoveDown = 5f;
    private float _zPozitionToMoveDown = -9f;

    private void Start()
    {
        foreach (var road in _roadsPrefabs)
        {
            Initialize(road);
        }

        _distanceBetweenRoad = _roadsPrefabs[0].GetComponent<Renderer>().bounds.size.z;
    }

    private void Update()
    {
        Move();

        if (_currentRoadsCount != _maxCountPrefabsOnWay)
        {
            ActivateRoad();
        }

        DeactivateRoad();
    }

    private void SetRoad(GameObject road, float spawnPointsZ)
    {
        road.SetActive(true);
        road.transform.position = new Vector3(road.transform.position.x, road.transform.position.y, spawnPointsZ);
        _roads.Add(road);
        _currentRoadsCount++;
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
        if (_currentRoadsCount > 0 && _roads[0].transform.localPosition.z < _zPositionToDeactivate)
        {           
            _roads[0].SetActive(false);
            _roads.RemoveAt(0);
            _currentRoadsCount--;      
        }
    }

    private void MoveDown(GameObject road)
    {
        if (road.transform.localPosition.z < _zPozitionToMoveDown)
        {
             road.transform.DOMoveY(_endValueMoveDownY, _durationMoveDown);
        }
    }

    private void Move()
    {
        foreach (var road in _roads)
        {
            road.transform.Translate(Vector3.back * _speed * Time.deltaTime);
            MoveDown(road);
        }
    }
}
