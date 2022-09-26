using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _firstPath;
    [SerializeField] private List<GameObject> _secondPath;
    [SerializeField] private List<GameObject> _thirdPath;
    [SerializeField] private List<GameObject> _fourthPath;
    [SerializeField] private List<GameObject> _fifthPath;
    [SerializeField] private List<GameObject> _sixthPath;
    [SerializeField] private GameObject _finish;

    private List<GameObject> _roadPath = new List<GameObject>();
    private BoxCollider _boxCollider;
    private List<GameObject> _road = new List<GameObject>();
    //private Vector3 _finishRotation = new Vector3(0,180,0);
    private float _pathWidth;
    private Random _randomPath = new Random();

    private void Start()
    {
        _roadPath.Add(GetRandomPart(_firstPath));
        _roadPath.Add(GetRandomPart(_secondPath));
        _roadPath.Add(GetRandomPart(_thirdPath));
        _roadPath.Add(GetRandomPart(_fourthPath));
        _roadPath.Add((GetRandomPart(_fifthPath)));
        _roadPath.Add(GetRandomPart(_sixthPath));
        CreateRoad();
    }

    private void CreateRoad()
    {
        Vector3 position = Vector3.zero;
        //Vector3 finishWidth = new Vector3(0, 0, 9);

        for (int i = 0; i < _roadPath.Count; i++)
        {
            Vector3 width = new Vector3(_pathWidth, 0, 0);
            
            if (_road.Count > 0)
            {
                position = _road[_road.Count - 1].transform.position + width;
            }
            
            var road = Instantiate(_roadPath[i], position, Quaternion.identity);
            _pathWidth = road.GetComponent<BoxCollider>().bounds.size.x;
            road.transform.SetParent(transform);
            _road.Add(road);
        }
        //GameObject finish = Instantiate(_finish, position + finishWidth, Quaternion.Euler(_finishRotation), transform);
    }

    private GameObject GetRandomPart(List<GameObject> list)
    {
        int randomNumber = _randomPath.Next(0, list.Count);
        return list[randomNumber].gameObject;
    }
}
