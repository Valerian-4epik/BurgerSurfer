using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smooth;
    [SerializeField] private Vector3 _offset;
    
    float _deltaX;
    private bool _isActiveFinishPosition = false;
    
    public bool IsActiveFinishPosition
    {
        get { return _isActiveFinishPosition; }
        set { _isActiveFinishPosition = value; }
    }
    
    void Start()
    {
        _deltaX = transform.position.x - _target.position.x;
    }

    void Update()
    {
        Vector3 targerPosition = new Vector3(transform.position.x, _target.position.y, transform.position.z); 
        transform.position = new Vector3(_target.position.x + _deltaX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targerPosition + _offset, Time.deltaTime * _smooth);
        
        if(_isActiveFinishPosition)
            SetYOffset(18,10); //магические числа
             
    }

    public void SetYOffset(float yDistance, float duration)
    {
        _offset = Vector3.MoveTowards(_offset, new Vector3(_offset.x, yDistance, _offset.z), duration * Time.deltaTime);
        //_isActiveFinishPosition = false;
    }
}
