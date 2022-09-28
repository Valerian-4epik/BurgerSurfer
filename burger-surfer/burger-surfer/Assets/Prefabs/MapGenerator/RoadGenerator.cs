using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _startPath;
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
    private Vector3 _width;

    private void Start()
    {
        _roadPath.Add(_startPath);
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
            _width = new Vector3(_pathWidth, 0, 0);

            if (_road.Count > 0)
                position = _road[_road.Count - 1].transform.position + _width;
            
            var road = Instantiate(_roadPath[i], position, Quaternion.identity);
            _pathWidth = road.GetComponent<BoxCollider>().bounds.size.x;
            road.transform.SetParent(transform);
            _road.Add(road);
        }
        
        position = _road[_road.Count - 1].transform.position + _width/2;
        GameObject finish = Instantiate(_finish, position, Quaternion.identity);
        finish.transform.SetParent(transform);
        finish.GetComponentInChildren<Stopper>().GetCamera(_camera);
    }

    private GameObject GetRandomPart(List<GameObject> list)
    {
        int randomNumber = _randomPath.Next(0, list.Count);
        return list[randomNumber].gameObject;
    }
}
