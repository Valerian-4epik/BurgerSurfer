using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _roadPrefabs;
    [SerializeField] private GameObject _finish;
    [SerializeField] private int _roadLength;

    private BoxCollider _boxCollider;
    private List<GameObject> _road = new List<GameObject>();
    private Vector3 _finishRotation = new Vector3(0,180,0);
    private float _pathWidth;
    private Random _randomPath = new Random();
    
    private void Start()
    {
        CreateRoad();
    }

    private void CreateRoad()
    {
        Vector3 position = Vector3.zero;
        //Vector3 finishWidth = new Vector3(0, 0, 9);

        for (int i = 0; i < _roadLength; i++)
        {
            Vector3 width = new Vector3(_pathWidth, 0, 0);
            
            if (_road.Count > 0)
            {
                position = _road[_road.Count - 1].transform.position + width;
            }
            
            var road = Instantiate(GetRandomPart(), position, Quaternion.identity);
            _pathWidth = road.gameObject.GetComponent<BoxCollider>().bounds.size.x;
            Debug.Log(_pathWidth);
            
            road.transform.SetParent(transform);
            _road.Add(road);
        }
        //GameObject finish = Instantiate(_finish, position + finishWidth, Quaternion.Euler(_finishRotation), transform);
    }

    private GameObject GetRandomPart()
    {
        int randomNumber = _randomPath.Next(0, _roadPrefabs.Count);
        return _roadPrefabs[randomNumber].gameObject;
    }
}
