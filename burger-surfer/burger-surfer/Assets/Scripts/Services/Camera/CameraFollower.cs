using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;

    float _deltaX;

    void Start()
    {
        _deltaX = transform.position.x - _target.position.x;
    }

    void Update()
    {
        transform.position = new Vector3(_target.position.x + _deltaX, transform.position.y, transform.position.z);
    }
}
