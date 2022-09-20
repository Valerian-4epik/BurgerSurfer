using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smooth;
    [SerializeField] private Vector3 _offset;

    float _deltaX;

    void Start()
    {
        _deltaX = transform.position.x - _target.position.x;
    }

    void Update()
    {
        Vector3 targerPosition = new Vector3(transform.position.x, _target.position.y, transform.position.z); 
        transform.position = new Vector3(_target.position.x + _deltaX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targerPosition + _offset, Time.deltaTime * _smooth);
    }
}
